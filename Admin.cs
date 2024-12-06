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
                        MessageBox.Show("Ҫ���г����Ǽǣ�������Ҫ�й��Ȼ��Ҫ�л��");
                        Form categoryForm = new CategoryForm(this.Parameter);
                        categoryForm.Show();
                        categoryForm.MdiParent = this;
                    }
                    else
                    {
                        MessageBox.Show("������ӻ�����ܽ��г����Ǽǣ�");
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.Show();
        }

        private void �˳�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void ¼��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataFactory.ProductRepository().Any())
            {
                if (!DataFactory.CategoryRepository().Any())
                {
                    MessageBox.Show("Ҫ���г����Ǽǣ�������Ҫ�й��Ȼ��Ҫ�л��");
                    Form categoryForm = new CategoryForm(this.Parameter);
                    categoryForm.Show();
                    categoryForm.MdiParent = this;
                }
                else
                {
                    MessageBox.Show("������ӻ�����ܽ��г����Ǽǣ�");
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

        private void ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form categoryForm = new CategoryForm(this.Parameter);
            categoryForm.Show();
            categoryForm.MdiParent = this;
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DataFactory.CategoryRepository().Any())
            {
                MessageBox.Show("����ӹ�������ӻ��");
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

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�ֿ����ϵͳ\nCopyRight By YWS " + DateTime.Now.Year + "\nAll right reserved");
        }

        private void �±���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form monthlyReportForm = new MonthlyReportForm(this.Parameter);
            monthlyReportForm.Show();
            monthlyReportForm.MdiParent = this;
        }

        private void �������ϸToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form detailsForm = new DetailsForm(this.Parameter);
            detailsForm.Show();
            detailsForm.MdiParent = this;
        }

        private void ����ͳ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sumForm=new SumForm(this.Parameter);
            sumForm.Show();
            sumForm.MdiParent = this;
        }
    }
}
