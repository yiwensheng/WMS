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
    public partial class EditProduct : Form
    {
        public ProductInfo thisProductInfo;
        public EditProduct(ProductInfo productInfo)
        {
            InitializeComponent();
            thisProductInfo = productInfo;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            labelTitle.Text = "修改" + thisProductInfo.Name + "信息";
            textBoxName.Text = thisProductInfo.Name;
            comboBoxCategory.DataSource = DataFactory.CategoryRepository();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";
            comboBoxCategory.SelectedValue = thisProductInfo.CategoryId;
            textBoxPrice.Text = thisProductInfo.Price.ToString();
            textBoxInventory.Text = thisProductInfo.Inventory.ToString();
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
                string categoryId = comboBoxCategory.SelectedValue.ToString();
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
                        if(!Regex.IsMatch(inventory, @"^\d+$"))
                        {
                            MessageBox.Show("请输入有效的整数！");
                            textBoxInventory.Focus();
                        }
                        else
                        {
                            if(Convert.ToInt32(inventory) < 0)
                            {
                                MessageBox.Show("库存必须大于等于零！");
                                textBoxInventory.Focus();
                            }
                            else
                            {
                                string sql = "update Product set Name='" + name + "',CategoryId=" + categoryId + ",Inventory=" + inventory + ",Price=" + price + " where Id=" + thisProductInfo.Id;
                                int ok=WMSDateHelp.adddata(sql);
                                thisProductInfo = DataFactory.ProductInfoRepository().FirstOrDefault(t => t.Id == thisProductInfo.Id);
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
