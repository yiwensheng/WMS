namespace WMS
{
    partial class CategoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Ltitile = new Label();
            categoryBindingSource = new BindingSource(components);
            lblPagination = new Label();
            btnPreviousPage = new Button();
            btnNextPage = new Button();
            dataGridView1 = new DataGridView();
            Badd = new Button();
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(0, 0);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 1;
            Ltitile.Text = "规格管理";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // categoryBindingSource
            // 
            categoryBindingSource.DataSource = typeof(Category);
            // 
            // lblPagination
            // 
            lblPagination.AutoSize = true;
            lblPagination.Location = new Point(369, 647);
            lblPagination.Name = "lblPagination";
            lblPagination.Size = new Size(43, 17);
            lblPagination.TabIndex = 3;
            lblPagination.Text = "label2";
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(517, 639);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(88, 32);
            btnPreviousPage.TabIndex = 4;
            btnPreviousPage.Text = "上一页";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(611, 639);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(96, 32);
            btnNextPage.TabIndex = 5;
            btnNextPage.Text = "下一页";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(288, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(406, 578);
            dataGridView1.TabIndex = 6;
            // 
            // Badd
            // 
            Badd.BackColor = SystemColors.ActiveBorder;
            Badd.FlatAppearance.BorderColor = Color.Silver;
            Badd.Location = new Point(267, 639);
            Badd.Name = "Badd";
            Badd.Size = new Size(96, 32);
            Badd.TabIndex = 7;
            Badd.Text = "新增";
            Badd.UseVisualStyleBackColor = false;
            Badd.Click += Badd_Click;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(Badd);
            Controls.Add(dataGridView1);
            Controls.Add(btnNextPage);
            Controls.Add(btnPreviousPage);
            Controls.Add(lblPagination);
            Controls.Add(Ltitile);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "CategoryForm";
            ShowIcon = false;
            Text = "CategoryForm";
            WindowState = FormWindowState.Maximized;
            Load += CategoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Ltitile;
        private Label lblPagination;
        private Button btnPreviousPage;
        private Button btnNextPage;
        private BindingSource categoryBindingSource;
        private DataGridView dataGridView1;
        private Button Badd;
    }
}