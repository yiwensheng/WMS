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
    public partial class AddCategory : Form
    {
        private CategoryForm _parentForm;
        public AddCategory(CategoryForm parentForm)
        {
            InitializeComponent();
            this.textBox1.Leave += new EventHandler(textBox_Leave);
            _parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string category = textBox1.Text;
            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("不能为空！");
                textBox1.Focus();
            }
            else
            {
                if (DataFactory.CategoryRepository().Any(t => t.Name == category))
                {
                    MessageBox.Show("规格不能重复！");
                    textBox1.Focus();
                }
                else
                {
                    int ok = WMSDateHelp.adddata("insert into Category(Name) values('" + category + "')");
                    _parentForm.RefreshData();
                    this.Close();
                }
            }
        }
        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                MessageBox.Show("规格名称不能为空！");
                textBox.Focus(); // 将焦点设回TextBox
            }
        }

        private void AddCategory_Load(object sender, EventArgs e)
        {

        }
    }
}
