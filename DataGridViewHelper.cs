using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMS
{
    public class DataGridViewHelper
    {
        private DataGridView _dataGridView;
        private DataTable _dataTable;

        // 分页字段
        private int _pageSize = 10; // 每页显示行数
        private int _currentPage = 1; // 当前页码
        private int _totalPages = 1; // 总页数

        // 构造函数
        public DataGridViewHelper(DataGridView dataGridView,DataTable dt, List<string> headtext, int pageSize = 10)
        {
            _dataGridView = dataGridView;
            _dataGridView.AllowUserToAddRows = true;
            _dataGridView.AllowUserToDeleteRows = true;
            _dataGridView.ReadOnly = false;
            _dataGridView.RowHeadersVisible = false;//隐藏最左边的空白栏
            _dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//表头居中对齐
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//自适应宽度
            _pageSize = pageSize;

            int i = 0;
            foreach(DataColumn column in dt.Columns)
            {
                column.ColumnName = headtext[i];
                i++;
            }
            _dataTable = dt;

            // 设置表头样式
            _dataGridView.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter, // 中间对齐
                BackColor = Color.LightGray, // 表头背景色
                ForeColor = Color.Black, // 表头文字颜色
                Font = new Font("微软雅黑", 10F, FontStyle.Bold), // 表头字体
            };
            UpdatePagination();
        }

        // 更新分页信息
        private void UpdatePagination()
        {
            _totalPages = (int)Math.Ceiling((double)_dataTable.Rows.Count / _pageSize);
            _currentPage = Math.Min(_currentPage, _totalPages);
            LoadPage(_currentPage);
        }

        // 加载指定页的数据
        public void LoadPage(int pageNumber)
        {
            _currentPage = Math.Max(1, Math.Min(pageNumber, _totalPages));

            // 获取当前页的数据
            DataTable paginatedTable = _dataTable.Clone();
            int startRow = (_currentPage - 1) * _pageSize;
            int endRow = Math.Min(startRow + _pageSize, _dataTable.Rows.Count);

            for (int i = startRow; i < endRow; i++)
            {
                paginatedTable.ImportRow(_dataTable.Rows[i]);
            }

            _dataGridView.DataSource = paginatedTable;
        }

        // 下一页
        public void NextPage()
        {
            if (_currentPage < _totalPages)
            {
                LoadPage(++_currentPage);
            }
        }

        // 上一页
        public void PreviousPage()
        {
            if (_currentPage > 1)
            {
                LoadPage(--_currentPage);
            }
        }

        // 获取分页信息
        public string GetPaginationInfo()
        {
            return $"当前页: {_currentPage} / 总页数: {_totalPages}";
        }

        // 添加记录并更新分页
        public void AddRecord(int id, string name, int age)
        {
            try
            {
                DataRow newRow = _dataTable.NewRow();
                newRow["ID"] = id;
                newRow["Name"] = name;
                newRow["Age"] = age;
                _dataTable.Rows.Add(newRow);
                UpdatePagination();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"添加记录时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 删除记录并更新分页
        public void DeleteRecord(int id)
        {
            try
            {
                DataRow rowToDelete = _dataTable.Rows.Find(id);
                if (rowToDelete != null)
                {
                    _dataTable.Rows.Remove(rowToDelete);
                    UpdatePagination();
                }
                else
                {
                    MessageBox.Show("未找到指定的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除记录时出错: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

