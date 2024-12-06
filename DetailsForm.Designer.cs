namespace WMS
{
    partial class DetailsForm
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
            label1 = new Label();
            Ltitile = new Label();
            Bdate = new DateTimePicker();
            label2 = new Label();
            Edate = new DateTimePicker();
            ProductBox = new ComboBox();
            CategoryBox = new ComboBox();
            InOrOutBox = new ComboBox();
            WhoBox = new ComboBox();
            usersBindingSource = new BindingSource(components);
            TSearch = new TextBox();
            button1 = new Button();
            BtnDownLoadExcel = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(1, 69);
            label1.Name = "label1";
            label1.Size = new Size(914, 42);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(1, 1);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 4;
            Ltitile.Text = "出入库明细";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Bdate
            // 
            Bdate.Location = new Point(6, 44);
            Bdate.Name = "Bdate";
            Bdate.Size = new Size(130, 23);
            Bdate.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(142, 47);
            label2.Name = "label2";
            label2.Size = new Size(13, 17);
            label2.TabIndex = 6;
            label2.Text = "-";
            // 
            // Edate
            // 
            Edate.Location = new Point(161, 44);
            Edate.Name = "Edate";
            Edate.Size = new Size(129, 23);
            Edate.TabIndex = 7;
            // 
            // ProductBox
            // 
            ProductBox.FormattingEnabled = true;
            ProductBox.Location = new Point(296, 43);
            ProductBox.Name = "ProductBox";
            ProductBox.Size = new Size(121, 25);
            ProductBox.TabIndex = 8;
            // 
            // CategoryBox
            // 
            CategoryBox.FormattingEnabled = true;
            CategoryBox.Location = new Point(423, 43);
            CategoryBox.Name = "CategoryBox";
            CategoryBox.Size = new Size(121, 25);
            CategoryBox.TabIndex = 9;
            // 
            // InOrOutBox
            // 
            InOrOutBox.FormattingEnabled = true;
            InOrOutBox.Location = new Point(550, 43);
            InOrOutBox.Name = "InOrOutBox";
            InOrOutBox.Size = new Size(121, 25);
            InOrOutBox.TabIndex = 10;
            // 
            // WhoBox
            // 
            WhoBox.DataSource = usersBindingSource;
            WhoBox.DisplayMember = "Name";
            WhoBox.FormattingEnabled = true;
            WhoBox.Location = new Point(677, 43);
            WhoBox.Name = "WhoBox";
            WhoBox.Size = new Size(121, 25);
            WhoBox.TabIndex = 11;
            WhoBox.ValueMember = "Id";
            // 
            // usersBindingSource
            // 
            usersBindingSource.DataSource = typeof(Users);
            // 
            // TSearch
            // 
            TSearch.BorderStyle = BorderStyle.FixedSingle;
            TSearch.Location = new Point(804, 44);
            TSearch.Name = "TSearch";
            TSearch.PlaceholderText = "关键字搜索";
            TSearch.Size = new Size(100, 23);
            TSearch.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(910, 42);
            button1.Name = "button1";
            button1.Size = new Size(75, 27);
            button1.TabIndex = 13;
            button1.Text = "确定";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // BtnDownLoadExcel
            // 
            BtnDownLoadExcel.Location = new Point(366, 105);
            BtnDownLoadExcel.Name = "BtnDownLoadExcel";
            BtnDownLoadExcel.Size = new Size(193, 33);
            BtnDownLoadExcel.TabIndex = 14;
            BtnDownLoadExcel.Text = "生成出入库明细Excel文件";
            BtnDownLoadExcel.UseVisualStyleBackColor = true;
            BtnDownLoadExcel.Click += BtnDownLoadExcel_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(27, 144);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(950, 549);
            dataGridView1.TabIndex = 15;
            // 
            // DetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(dataGridView1);
            Controls.Add(BtnDownLoadExcel);
            Controls.Add(button1);
            Controls.Add(TSearch);
            Controls.Add(WhoBox);
            Controls.Add(InOrOutBox);
            Controls.Add(CategoryBox);
            Controls.Add(ProductBox);
            Controls.Add(Edate);
            Controls.Add(label2);
            Controls.Add(Bdate);
            Controls.Add(Ltitile);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DetailsForm";
            Text = "DetailsForm";
            WindowState = FormWindowState.Maximized;
            Load += DetailsForm_Load;
            ((System.ComponentModel.ISupportInitialize)usersBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Ltitile;
        private DateTimePicker Bdate;
        private Label label2;
        private DateTimePicker Edate;
        private ComboBox ProductBox;
        private ComboBox CategoryBox;
        private ComboBox InOrOutBox;
        private ComboBox WhoBox;
        private TextBox TSearch;
        private Button button1;
        private BindingSource usersBindingSource;
        private Button BtnDownLoadExcel;
        private DataGridView dataGridView1;
        private TextBox textBox1;
    }
}