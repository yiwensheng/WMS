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
    public partial class SumForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Parameter { get; set; }
        public DataGridViewHelper _dataGridViewHelper;
        public string bdate = DateTime.Now.ToString("yyyy-MM") + "-01";
        public string edate = DateTime.Now.ToString("yyyy-MM-dd");

        public SumForm(string parameter)
        {
            InitializeComponent();
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Parameter = parameter;
            this.Text = "汇总统计";
        }

        private void SumForm_Load(object sender, EventArgs e)
        {

        }
    }
}
