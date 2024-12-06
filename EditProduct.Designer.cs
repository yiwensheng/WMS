namespace WMS
{
    partial class EditProduct
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
            labelTitle = new Label();
            label1 = new Label();
            textBoxName = new TextBox();
            label2 = new Label();
            comboBoxCategory = new ComboBox();
            label3 = new Label();
            textBoxPrice = new TextBox();
            label4 = new Label();
            textBoxInventory = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.Font = new Font("Microsoft YaHei UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 134);
            labelTitle.Location = new Point(12, 2);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(600, 27);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "label1";
            labelTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(600, 23);
            label1.TabIndex = 1;
            label1.Text = "货物名称：";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxName
            // 
            textBoxName.BorderStyle = BorderStyle.FixedSingle;
            textBoxName.Location = new Point(12, 77);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(600, 23);
            textBoxName.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(12, 103);
            label2.Name = "label2";
            label2.Size = new Size(600, 23);
            label2.TabIndex = 3;
            label2.Text = "货物规格：";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(12, 129);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(600, 25);
            comboBoxCategory.TabIndex = 4;
            // 
            // label3
            // 
            label3.Location = new Point(12, 157);
            label3.Name = "label3";
            label3.Size = new Size(600, 23);
            label3.TabIndex = 5;
            label3.Text = "单价：";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxPrice
            // 
            textBoxPrice.BorderStyle = BorderStyle.FixedSingle;
            textBoxPrice.Location = new Point(12, 183);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(600, 23);
            textBoxPrice.TabIndex = 6;
            // 
            // label4
            // 
            label4.Location = new Point(12, 209);
            label4.Name = "label4";
            label4.Size = new Size(600, 23);
            label4.TabIndex = 7;
            label4.Text = "初始库存：";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxInventory
            // 
            textBoxInventory.BorderStyle = BorderStyle.FixedSingle;
            textBoxInventory.Location = new Point(12, 235);
            textBoxInventory.Name = "textBoxInventory";
            textBoxInventory.Size = new Size(600, 23);
            textBoxInventory.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            button1.Location = new Point(255, 278);
            button1.Name = "button1";
            button1.Size = new Size(119, 37);
            button1.TabIndex = 9;
            button1.Text = "修改";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EditProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 361);
            Controls.Add(button1);
            Controls.Add(textBoxInventory);
            Controls.Add(label4);
            Controls.Add(textBoxPrice);
            Controls.Add(label3);
            Controls.Add(comboBoxCategory);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Controls.Add(labelTitle);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "修改货物";
            Load += EditProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitle;
        private Label label1;
        private TextBox textBoxName;
        private Label label2;
        private ComboBox comboBoxCategory;
        private Label label3;
        private TextBox textBoxPrice;
        private Label label4;
        private TextBox textBoxInventory;
        private Button button1;
    }
}