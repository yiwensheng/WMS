using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class MonthlyReportForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public DataGridViewHelper _dataGridViewHelper;
        public string thismonth = DateTime.Now.ToString("yyyy-MM");

        public MonthlyReportForm(string parameter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Parameter = parameter;
            this.Text = "月报表";

        }

        private void MonthlyReportForm_Load(object sender, EventArgs e)
        {
            dateTimePickerMonth.Format = DateTimePickerFormat.Custom;
            dateTimePickerMonth.CustomFormat = "yyyy-MM";
            dateTimePickerMonth.ShowUpDown = true;
            GetMonthSum(thismonth);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thismonth = dateTimePickerMonth.Text;
            GetMonthSum(thismonth);

        }
        public void GetMonthSum(string thismonth)
        {
            label1.Text = thismonth + "月报表";

            DataTable dt = WMSDateHelp.Filldata("select Id,Name,CategoryName,Price,Inventory,Total from ProductInfo order by Name,CategoryId").Tables[0];
            List<string> headerlist = new List<string>() { "序号", "名称", "规格", "单价", "库存", "总价" };

            int thisyear = Convert.ToInt32(thismonth.Split('-')[0]);
            int monthnumber = Convert.ToInt32(thismonth.Split("-")[1]);
            int days = DateTime.DaysInMonth(thisyear, monthnumber);
            for (int i = 1; i <= days; i++)
            {
                headerlist.Add(i + "入");
                headerlist.Add(i + "出");
                dt.Columns.Add("In" + i);
                dt.Columns.Add("Out" + i);
            }
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 1; i <= days; i++)
                {
                    string tempdate = thismonth + "-" + (i < 10 ? "0" + i : i);
                    string sql = "SELECT InOrOut,SUM(Quantity) AS total FROM BankInfo WHERE ProductId=" + row["Id"].ToString() + " AND DayDate='" + tempdate + "' GROUP BY InOrOut ORDER BY InOrOut DESC";
                    DataTable daysInorOut = WMSDateHelp.Filldata(sql).Tables[0];
                    foreach (DataRow subRow in daysInorOut.Rows)
                    {
                        if (subRow["InOrOut"].ToString() == "入库")
                        {
                            row["In" + i] = subRow["total"].ToString();
                        }
                        if (subRow["InOrOut"].ToString() == "出库")
                        {
                            row["Out" + i] = subRow["total"].ToString();
                        }
                    }
                    daysInorOut.Dispose();
                }
            }
            _dataGridViewHelper = new DataGridViewHelper(dataGridView1, dt, headerlist, DataFactory.ProductRepository().Count());
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WMSDateHelp.ExportToExcel(dataGridView1, thismonth + "月报表", "月报表");
        }
    }
}
