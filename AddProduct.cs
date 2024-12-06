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
    public partial class AddProduct : Form
    {
        private ProductForm _parentForm;
        public AddProduct(ProductForm parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DataSource = DataFactory.CategoryRepository();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
            comboBoxCategory.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Regex.Replace(textBoxName.Text, @"\s", "");
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("货物名称不能为空！");
                textBoxName.Focus();
            }
            else
            {
                string categoryId =comboBoxCategory.SelectedIndex==-1?"":comboBoxCategory.SelectedValue.ToString();
                if (string.IsNullOrEmpty(categoryId))
                {
                    MessageBox.Show("货物规格必须要选！");
                }
                else
                {
                    string price = Regex.Replace(textBoxPrice.Text, @"\s", "");
                    if (!System.Text.RegularExpressions.Regex.IsMatch(price, @"^[0-9]*(\.[0-9]*)?$"))
                    {
                        MessageBox.Show("请输入有效的数值！");
                        textBoxPrice.Focus();
                    }
                    else
                    {
                        if (Convert.ToDecimal(price) <= 0)
                        {
                            MessageBox.Show("必须大于零！");
                            textBoxPrice.Focus();
                        }
                        else
                        {
                            string inventory = Regex.Replace(textBoxInventory.Text, @"\s", "");
                            if (!Regex.IsMatch(inventory, @"^\d+$"))
                            {
                                MessageBox.Show("请输入有效的整数！");
                                textBoxInventory.Focus();
                            }
                            else
                            {
                                if (Convert.ToInt32(inventory) < 0)
                                {
                                    MessageBox.Show("库存必须大于等于零！");
                                    textBoxInventory.Focus();
                                }
                                else
                                {
                                    if (DataFactory.ProductRepository().Any(t => t.Name == name && t.CategoryId.ToString() == categoryId && t.Price.ToString() == price))
                                    {
                                        MessageBox.Show("已有该货物，不能重复添加！");
                                    }
                                    else
                                    {
                                        string sql = "insert into Product(Name,CategoryId,Inventory,Price) values('" + name + "'," + categoryId + "," + inventory + "," + price + ")";
                                        int ok = WMSDateHelp.adddata(sql);
                                        _parentForm.RefreshData();
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
