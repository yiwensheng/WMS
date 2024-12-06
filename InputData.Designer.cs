namespace WMS
{
    partial class InputData
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
            dateTimePickerInput = new DateTimePicker();
            comboBoxProduct = new ComboBox();
            productInfoBindingSource = new BindingSource(components);
            comboBoxCategory = new ComboBox();
            categoryBindingSource = new BindingSource(components);
            textBoxKey = new TextBox();
            buttonOk = new Button();
            labelTitle = new Label();
            dataGridView1 = new DataGridView();
            btnNextPage = new Button();
            btnPreviousPage = new Button();
            lblPagination = new Label();
            ((System.ComponentModel.ISupportInitialize)productInfoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(1, 1);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 2;
            Ltitile.Text = "录入";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerInput
            // 
            dateTimePickerInput.Location = new Point(204, 43);
            dateTimePickerInput.Name = "dateTimePickerInput";
            dateTimePickerInput.Size = new Size(140, 23);
            dateTimePickerInput.TabIndex = 3;
            // 
            // comboBoxProduct
            // 
            comboBoxProduct.DataSource = productInfoBindingSource;
            comboBoxProduct.DisplayMember = "Name";
            comboBoxProduct.FormattingEnabled = true;
            comboBoxProduct.Location = new Point(343, 43);
            comboBoxProduct.Name = "comboBoxProduct";
            comboBoxProduct.Size = new Size(121, 25);
            comboBoxProduct.TabIndex = 4;
            comboBoxProduct.ValueMember = "Id";
            // 
            // productInfoBindingSource
            // 
            productInfoBindingSource.DataSource = typeof(ProductInfo);
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.DataSource = categoryBindingSource;
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(463, 43);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(121, 25);
            comboBoxCategory.TabIndex = 5;
            comboBoxCategory.ValueMember = "Id";
            // 
            // categoryBindingSource
            // 
            categoryBindingSource.DataSource = typeof(Category);
            // 
            // textBoxKey
            // 
            textBoxKey.Location = new Point(584, 43);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.Size = new Size(100, 23);
            textBoxKey.TabIndex = 6;
            // 
            // buttonOk
            // 
            buttonOk.Location = new Point(681, 43);
            buttonOk.Name = "buttonOk";
            buttonOk.Size = new Size(75, 25);
            buttonOk.TabIndex = 7;
            buttonOk.Text = "确定";
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.Click += buttonOk_Click;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Microsoft YaHei UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelTitle.Location = new Point(371, 84);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(75, 28);
            labelTitle.TabIndex = 8;
            labelTitle.Text = "label1";
            labelTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(204, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(552, 150);
            dataGridView1.TabIndex = 9;
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(557, 650);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(96, 32);
            btnNextPage.TabIndex = 12;
            btnNextPage.Text = "下一页";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(463, 650);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(88, 32);
            btnPreviousPage.TabIndex = 11;
            btnPreviousPage.Text = "上一页";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // lblPagination
            // 
            lblPagination.AutoSize = true;
            lblPagination.Location = new Point(315, 658);
            lblPagination.Name = "lblPagination";
            lblPagination.Size = new Size(43, 17);
            lblPagination.TabIndex = 10;
            lblPagination.Text = "label2";
            // 
            // InputData
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(btnNextPage);
            Controls.Add(btnPreviousPage);
            Controls.Add(lblPagination);
            Controls.Add(dataGridView1);
            Controls.Add(labelTitle);
            Controls.Add(buttonOk);
            Controls.Add(textBoxKey);
            Controls.Add(comboBoxCategory);
            Controls.Add(comboBoxProduct);
            Controls.Add(dateTimePickerInput);
            Controls.Add(Ltitile);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InputData";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "InputData";
            WindowState = FormWindowState.Maximized;
            Load += InputData_Load;
            ((System.ComponentModel.ISupportInitialize)productInfoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)categoryBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label Ltitile;
        private DateTimePicker dateTimePickerInput;
        private ComboBox comboBoxProduct;
        private BindingSource productInfoBindingSource;
        private ComboBox comboBoxCategory;
        private TextBox textBoxKey;
        private Button buttonOk;
        private BindingSource categoryBindingSource;
        private Label labelTitle;
        private DataGridView dataGridView1;
        private Button btnNextPage;
        private Button btnPreviousPage;
        private Label lblPagination;
    }
}