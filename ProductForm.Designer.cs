namespace WMS
{
    partial class ProductForm
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
            Ltitile = new Label();
            dataGridView1 = new DataGridView();
            Badd = new Button();
            btnNextPage = new Button();
            btnPreviousPage = new Button();
            lblPagination = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(0, 0);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 2;
            Ltitile.Text = "货物管理";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(90, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 578);
            dataGridView1.TabIndex = 3;
            // 
            // Badd
            // 
            Badd.BackColor = SystemColors.ActiveBorder;
            Badd.FlatAppearance.BorderColor = Color.Silver;
            Badd.Location = new Point(267, 646);
            Badd.Name = "Badd";
            Badd.Size = new Size(96, 32);
            Badd.TabIndex = 11;
            Badd.Text = "新增";
            Badd.UseVisualStyleBackColor = false;
            Badd.Click += Badd_Click;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(611, 646);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(96, 32);
            btnNextPage.TabIndex = 10;
            btnNextPage.Text = "下一页";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(517, 646);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(88, 32);
            btnPreviousPage.TabIndex = 9;
            btnPreviousPage.Text = "上一页";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // lblPagination
            // 
            lblPagination.AutoSize = true;
            lblPagination.Location = new Point(369, 654);
            lblPagination.Name = "lblPagination";
            lblPagination.Size = new Size(43, 17);
            lblPagination.TabIndex = 8;
            lblPagination.Text = "label2";
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(Badd);
            Controls.Add(btnNextPage);
            Controls.Add(btnPreviousPage);
            Controls.Add(lblPagination);
            Controls.Add(dataGridView1);
            Controls.Add(Ltitile);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "ProductForm";
            ShowIcon = false;
            Text = "ProductForm";
            WindowState = FormWindowState.Maximized;
            Load += ProductForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Ltitile;
        private DataGridView dataGridView1;
        private Button Badd;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private Label lblPagination;
    }
}