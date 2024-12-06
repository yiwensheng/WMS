using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class DetailsForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public DataGridViewHelper _dataGridViewHelper;
        public string bdate = DateTime.Now.ToString("yyyy-MM") + "-01";
        public string edate = DateTime.Now.ToString("yyyy-MM-dd");

        public DetailsForm(string parameter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Parameter = parameter;
            this.Text = "出入库明细";
            Bdate.Format = DateTimePickerFormat.Custom;
            Bdate.CustomFormat = "yyyy-MM-dd";
            Bdate.Text = bdate;
            Edate.Format = DateTimePickerFormat.Custom;
            Edate.CustomFormat = "yyyy-MM-dd";
            Edate.Text = edate;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 检查是否是目标列，例如第 1 列（索引从 0 开始）
            if (dataGridView1.Columns[e.ColumnIndex].Name == "出入库") // 替换为你的列名
            {
                // 获取单元格的值
                var cellValue = e.Value?.ToString();
                if (cellValue == "入库")
                {
                    e.CellStyle.ForeColor = Color.Red;  // 高亮为红色
                    e.CellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Black; // 默认黑色
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetDetails();
        }
        public void GetDetails()
        {
            bdate = Bdate.Text;
            edate = Edate.Text;
            label1.Text = bdate + "至" + edate + "出入库记录";
            string sql = "select ROW_NUMBER() OVER (ORDER BY ProductId,DoDateTime) AS Id,ProductName,CategoryName,Price,Inventory,Total,InorOut,Quantity,Quantity*Price as Money,Who,DoDateTime,Remaining,RemainingMoney from BankInfo where DayDate>='" + bdate + "' and DayDate<='" + Convert.ToDateTime(edate).AddDays(1).ToString("yyyy-MM-dd") + "'";
            string thisproductId = ProductBox.SelectedIndex == -1 ? "" : ProductBox.SelectedValue.ToString();
            if(!string.IsNullOrEmpty(thisproductId))
            {
                sql += " and ProductId=" + thisproductId;
            }
            string thiscategoryId=CategoryBox.SelectedIndex==-1?"":CategoryBox.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(thiscategoryId))
            {
                sql += " and CategoryId=" + thiscategoryId;
            }
            string thisInOrOut = InOrOutBox.SelectedIndex == -1 ? "" : InOrOutBox.SelectedValue.ToString();
            if(!string.IsNullOrEmpty(thisInOrOut))
            {
                sql += " and InOrOut='" + thisInOrOut + "'";
            }
            string thisWhoId=WhoBox.SelectedIndex==-1?"":WhoBox.SelectedValue.ToString();
            if(!string.IsNullOrEmpty(thisWhoId))
            {
                sql += " and WhoId=" + thisWhoId;
            }
            string name = Regex.Replace(TSearch.Text, @"\s", "");
            if (!string.IsNullOrEmpty(name))
            {
                sql += " and (ProductName like '%" + name + "%' or CategoryName like '%" + name + "%')";
            }
            sql += " order by ProductId,DoDateTime";
            DataTable dt = WMSDateHelp.Filldata(sql).Tables[0];
            int all = dt.Rows.Count;
            List<string> headerlist = new List<string>() { "序号", "名称", "规格", "单价", "库存", "总价", "出入库", "数量", "费用", "操作者", "日期时间", "剩余", "剩余总价" };
            _dataGridViewHelper = new DataGridViewHelper(dataGridView1, dt, headerlist, all);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void DetailsForm_Load(object sender, EventArgs e)
        {
            ProductBox.DataSource = DataFactory.ProductRepository();
            ProductBox.DisplayMember = "Name";
            ProductBox.ValueMember = "Id";
            ProductBox.SelectedIndex = -1;
            ProductBox.Text = "货物";
            CategoryBox.DataSource = DataFactory.CategoryRepository();
            CategoryBox.DisplayMember = "Name";
            CategoryBox.ValueMember = "Id";
            CategoryBox.SelectedIndex = -1;
            CategoryBox.Text = "规格";
            InOrOutBox.DataSource = new List<string>() { "入库", "出库" };
            InOrOutBox.SelectedIndex = -1;
            InOrOutBox.Text = "出入库";
            WhoBox.DataSource = DataFactory.UsersRepository("select * from Users where Id>1");
            WhoBox.DisplayMember = "Name";
            WhoBox.ValueMember = "Id";
            WhoBox.SelectedIndex = -1;
            WhoBox.Text = "操作者";
            GetDetails();
        }

        private void BtnDownLoadExcel_Click(object sender, EventArgs e)
        {
            WMSDateHelp.ExportToExcel(dataGridView1, label1.Text, "出入库记录");
        }
    }
}
