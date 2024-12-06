using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using Microsoft.VisualBasic;

namespace WMS
{
    public partial class InputData : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }

        public DataGridViewHelper _dataGridViewHelper;
        public string thisdate = DateTime.Now.ToString("yyyy-MM-dd");
        public Users my = new Users();

        public InputData(string parameter)
        {
            InitializeComponent();
            Parameter = parameter;
            this.StartPosition = FormStartPosition.Manual;
            this.Text = "录入";
            my = DataFactory.UsersRepository().FirstOrDefault(t => t.Id.ToString() == this.Parameter);
        }
        private void InputData_Load(object sender, EventArgs e)
        {
            comboBoxProduct.DataSource = DataFactory.ProductRepository();
            comboBoxProduct.SelectedIndex = -1;
            comboBoxCategory.DataSource = DataFactory.CategoryRepository();
            comboBoxCategory.SelectedIndex = -1;
            textBoxKey.PlaceholderText = "关键词搜索……";
            labelTitle.Text = thisdate + "出入库登记";
            RefreshData();
            AddButtonColumns(dataGridView1);
            this.dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            thisdate = Convert.ToDateTime(dateTimePickerInput.Text).ToString("yyyy-MM-dd");
            labelTitle.Text = thisdate + "出入库登记";
            RefreshData();
        }
        public void RefreshData()
        {
            string thisProductId = comboBoxProduct.SelectedIndex != -1 ? comboBoxProduct.SelectedValue.ToString() : "";
            string thisCateGoryId = comboBoxCategory.SelectedIndex != -1 ? comboBoxCategory.SelectedValue.ToString() : "";
            string thiskeyword = Regex.Replace(textBoxKey.Text, @"\s", "");
            string sql = "select Id,Name,CategoryName,Inventory,Price,Total from ProductInfo where 1=1";
            if (!string.IsNullOrEmpty(thisProductId))
            {
                sql += " and Id=" + thisProductId;
            }
            if (!string.IsNullOrEmpty(thisCateGoryId))
            {
                sql += " and CateGoryId=" + thisCateGoryId;
            }
            if (!string.IsNullOrEmpty(thiskeyword))
            {
                sql += " and (Name like '%" + thiskeyword + "%' or CategoryName like '%" + thiskeyword + "%')";
            }
            sql += " order by Name,CategoryId";
            DataTable dt = WMSDateHelp.Filldata(sql).Tables[0];
            List<string> headname = new List<string>() { "Id","名称", "规格", "库存", "单价", "总价" };
            _dataGridViewHelper = new DataGridViewHelper(dataGridView1, dt, headname, 20);
            UpdatePaginationLabel();
            dataGridView1.AllowUserToAddRows = false;

        }
        public void UpdatePaginationLabel()
        {
            lblPagination.Text = _dataGridViewHelper.GetPaginationInfo();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            _dataGridViewHelper.PreviousPage();
            UpdatePaginationLabel();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            _dataGridViewHelper.NextPage();
            UpdatePaginationLabel();
        }
        private void AddButtonColumns(DataGridView dataGridView)
        {
            // 添加“入库”列
            DataGridViewTextBoxColumn inColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "入库",
                Name = "inColumn",
                DefaultCellStyle = { NullValue = "0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            inColumn.DefaultCellStyle.BackColor = Color.Red;
            inColumn.DefaultCellStyle.ForeColor = Color.Yellow;
            dataGridView.Columns.Add(inColumn);

            // 添加“出库”列
            DataGridViewTextBoxColumn outColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "出库",
                Name = "outColumn",
                DefaultCellStyle = { NullValue = "0", Alignment = DataGridViewContentAlignment.MiddleRight }
            };
            outColumn.DefaultCellStyle.BackColor = Color.Black;
            outColumn.DefaultCellStyle.ForeColor = Color.White;
            dataGridView.Columns.Add(outColumn);
        }
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //入库
            if (dataGridView1.Columns[e.ColumnIndex].Name == "inColumn")
            {
                int rowIndex = e.RowIndex;
                string indata = Regex.Replace(dataGridView1.Rows[rowIndex].Cells["inColumn"].Value.ToString(), @"\s", "");
                if (!Regex.IsMatch(indata, @"^\d+$"))
                {
                    MessageBox.Show("请输入有效的数字！");
                }
                else
                {
                    if (indata != "0")
                    {
                        string id = dataGridView1.Rows[rowIndex].Cells["Id"].Value.ToString();
                        //"单价", "库存"
                        string price = dataGridView1.Rows[rowIndex].Cells["单价"].Value.ToString();
                        string inventory = dataGridView1.Rows[rowIndex].Cells["库存"].Value.ToString();
                        int newinventory = Convert.ToInt32(inventory) + Convert.ToInt32(indata);
                        List<string> sqllist = new List<string>() {
                            "insert into Bank(ProductId,InOrOut,Quantity,DayDate,DodateTime,WhoId,Remaining,RemainingMoney) values(" + id + ",'入库'," + indata + ",'" + thisdate + "','"+DateTime.Now.ToString().Replace("/","-")+"'," + my.Id + "," + newinventory + "," + (newinventory * Convert.ToDecimal(price)) + ")",
                            "update Product set Inventory=" + newinventory + " where Id=" + id
                        };
                        int ok=WMSDateHelp.ExecuteSqlTran(sqllist);
                        RefreshData();
                    }
                }
            }
            //出库
            if (dataGridView1.Columns[e.ColumnIndex].Name == "outColumn")
            {
                int rowIndex = e.RowIndex;
                string outdata = Regex.Replace(dataGridView1.Rows[rowIndex].Cells["outColumn"].Value.ToString(), @"\s", "");
                if (!Regex.IsMatch(outdata, @"^\d+$"))
                {
                    MessageBox.Show("请输入有效的数字！");
                }
                else
                {
                    if (outdata != "0")
                    {
                        string id = dataGridView1.Rows[rowIndex].Cells["Id"].Value.ToString();
                        //"单价", "库存"
                        string price = dataGridView1.Rows[rowIndex].Cells["单价"].Value.ToString();
                        string inventory = dataGridView1.Rows[rowIndex].Cells["库存"].Value.ToString();
                        int newinventory = Convert.ToInt32(inventory) - Convert.ToInt32(outdata);
                        if (newinventory >= 0)
                        {
                            List<string> sqllist = new List<string>() {
                            "insert into Bank(ProductId,InOrOut,Quantity,DayDate,DodateTime,WhoId,Remaining,RemainingMoney) values(" + id + ",'出库'," + outdata + ",'" + thisdate + "','"+DateTime.Now.ToString().Replace("/","-")+"'," + my.Id + "," + newinventory + "," + (newinventory * Convert.ToDecimal(price)) + ")",
                            "update Product set Inventory=" + newinventory + " where Id=" + id
                            };
                            int ok = WMSDateHelp.ExecuteSqlTran(sqllist);
                            RefreshData();
                        }
                        else
                        {
                            MessageBox.Show("出库数量不能多于库存量！");
                            RefreshData();
                        }
                    }
                }
            }
        }
    }
}
