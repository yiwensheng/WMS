using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public partial class CategoryForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public DataGridViewHelper _dataGridViewHelper;

        public CategoryForm(string parameter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Parameter = parameter;
            this.Text = "规格管理";
            RefreshData();
            AddButtonColumns(dataGridView1);
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        public void RefreshData()
        {
            DataTable dt = WMSDateHelp.Filldata("select * from Category order by Id").Tables[0];
            List<string> headname = new List<string>() { "Id", "规格名称" };
            _dataGridViewHelper = new DataGridViewHelper(dataGridView1, dt, headname, 20);
            UpdatePaginationLabel();
            dataGridView1.AllowUserToAddRows = false;
        }

        public void UpdatePaginationLabel()
        {
            lblPagination.Text = _dataGridViewHelper.GetPaginationInfo();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
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
                string name = dataGridView1.Rows[rowIndex].Cells["规格名称"].Value.ToString();

                // 弹出对话框模拟修改
                string newName = Microsoft.VisualBasic.Interaction.InputBox("修改名称：", "修改记录", name);
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    dataGridView1.Rows[rowIndex].Cells["规格名称"].Value = newName;
                    int ok = WMSDateHelp.adddata("update Category set Name='" + newName + "' where Id=" + id);
                    UpdatePaginationLabel();
                }
            }
            // 判断点击的列是否是“删除”列
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "DeleteButton")
            {
                // 确认删除
                if (MessageBox.Show("确定要删除这条记录吗？", "删除确认", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    int ok = WMSDateHelp.adddata("delete from Category where Id=" + id);
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
            AddCategory addCategory = new AddCategory(this);
            addCategory.Owner = this;
            addCategory.ShowDialog();
        }
    }
}
