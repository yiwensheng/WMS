using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class ProductForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public DataGridViewHelper _dataGridViewHelper;

        public ProductForm(string parameter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Parameter = parameter;
            this.Text = "货物管理";
            RefreshData();
            AddButtonColumns(dataGridView1);
            dataGridView1.CellClick += dataGridView1_CellClick;

        }
        public void RefreshData()
        {
            DataTable dt = WMSDateHelp.Filldata("select Id,Name,CategoryName,Inventory,Price,Total from ProductInfo order by Id").Tables[0];
            List<string> headname = new List<string>() { "Id", "名称", "规格", "库存", "单价", "库存总价" };
            _dataGridViewHelper = new DataGridViewHelper(dataGridView1, dt, headname, 20);
            UpdatePaginationLabel();
            dataGridView1.AllowUserToAddRows = false;
        }
        public void UpdatePaginationLabel()
        {
            lblPagination.Text = _dataGridViewHelper.GetPaginationInfo();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {

        }
        private void AddButtonColumns(DataGridView dataGridView)
        {
            // 添加“修改”按钮列
            DataGridViewButtonColumn editButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "操作",
                Text = "修改",
                Name = "EditButton",
                UseColumnTextForButtonValue = true // 按钮显示固定文本
            };
            dataGridView.Columns.Add(editButtonColumn);

            // 添加“删除”按钮列
            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "删除",
                Text = "删除",
                Name = "DeleteButton",
                UseColumnTextForButtonValue = true
            };
            dataGridView.Columns.Add(deleteButtonColumn);
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 确保不是标题行或无效单元格
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            // 判断点击的列是否是“修改”列
            if (dataGridView1.Columns[e.ColumnIndex].Name == "EditButton")
            {
                // 获取当前行数据并执行修改操作
                int rowIndex = e.RowIndex;
                string id = dataGridView1.Rows[rowIndex].Cells["Id"].Value.ToString();
                EditProduct editProduct = new EditProduct(DataFactory.ProductInfoRepository().FirstOrDefault(t => t.Id.ToString() == id));
                if (editProduct.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["名称"].Value = editProduct.thisProductInfo.Name;
                    dataGridView1.Rows[e.RowIndex].Cells["规格"].Value = editProduct.thisProductInfo.CategoryName;
                    dataGridView1.Rows[e.RowIndex].Cells["单价"].Value = editProduct.thisProductInfo.Price;
                    dataGridView1.Rows[e.RowIndex].Cells["库存"].Value = editProduct.thisProductInfo.Inventory;
                    dataGridView1.Rows[e.RowIndex].Cells["库存总价"].Value = editProduct.thisProductInfo.Total;
                }
            }
            // 判断点击的列是否是“删除”列
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // 确认删除
                if (MessageBox.Show("确定要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    int ok = WMSDateHelp.adddata("delete from Product where Id=" + id);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
            RefreshData();
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

        private void Badd_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(this);
            addProduct.Owner = this;
            addProduct.ShowDialog();
        }
    }
}
