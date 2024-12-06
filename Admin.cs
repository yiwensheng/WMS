using System.ComponentModel;

namespace WMS
{
    public partial class Admin : Form
    {
        public string title = DataFactory.SystemInfoRepository().FirstOrDefault(t => t.Id == 1).Title;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public Admin(string parameter)
        {
            InitializeComponent();
            Parameter = parameter;
            this.Text = title;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Users my = DataFactory.UsersRepository().FirstOrDefault(t => t.Id.ToString() == this.Parameter);
            if (my == null)
            {
                this.Close();
                Login login = new Login();
                login.Show();
            }
            else
            {
                if (!DataFactory.ProductRepository().Any())
                {
                    if (!DataFactory.CategoryRepository().Any())
                    {
                        MessageBox.Show("要进行出入库登记，必须先要有规格，然后要有货物！");
                        Form categoryForm = new CategoryForm(this.Parameter);
                        categoryForm.Show();
                        categoryForm.MdiParent = this;
                    }
                    else
                    {
                        MessageBox.Show("请先添加货物才能进行出入库登记！");
                        Form productForm = new ProductForm(this.Parameter);
                        productForm.Show();
                        productForm.MdiParent = this;
                    }
                }
                else
                {
                    Form inputData = new InputData(this.Parameter);
                    inputData.Show();
                    inputData.MdiParent = this;
                }
            }
        }

        private void 锁屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void 录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataFactory.ProductRepository().Any())
            {
                if (!DataFactory.CategoryRepository().Any())
                {
                    MessageBox.Show("要进行出入库登记，必须先要有规格，然后要有货物！");
                    Form categoryForm = new CategoryForm(this.Parameter);
                    categoryForm.Show();
                    categoryForm.MdiParent = this;
                }
                else
                {
                    MessageBox.Show("请先添加货物才能进行出入库登记！");
                    Form productForm = new ProductForm(this.Parameter);
                    productForm.Show();
                    productForm.MdiParent = this;
                }
            }
            else
            {
                Form inputData = new InputData(this.Parameter);
                inputData.Show();
                inputData.MdiParent = this;
            }
        }

        private void 规格管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form categoryForm = new CategoryForm(this.Parameter);
            categoryForm.Show();
            categoryForm.MdiParent = this;
        }

        private void 货物管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataFactory.CategoryRepository().Any())
            {
                MessageBox.Show("先添加规格才能添加货物！");
                Form categoryForm = new CategoryForm(this.Parameter);
                categoryForm.Show();
                categoryForm.MdiParent = this;
            }
            else
            {
                Form productForm = new ProductForm(this.Parameter);
                productForm.Show();
                productForm.MdiParent = this;
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("仓库管理系统\nCopyRight By YWS " + DateTime.Now.Year + "\nAll right reserved");
        }

        private void 月报表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form monthlyReportForm = new MonthlyReportForm(this.Parameter);
            monthlyReportForm.Show();
            monthlyReportForm.MdiParent = this;
        }

        private void 出入库明细ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form detailsForm = new DetailsForm(this.Parameter);
            detailsForm.Show();
            detailsForm.MdiParent = this;
        }

        private void 汇总统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sumForm=new SumForm(this.Parameter);
            sumForm.Show();
            sumForm.MdiParent = this;
        }
    }
}
