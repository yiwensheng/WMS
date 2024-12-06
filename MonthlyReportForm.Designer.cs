namespace WMS
{
    partial class MonthlyReportForm
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
            Lchoosemonth = new Label();
            Ltitile = new Label();
            dateTimePickerMonth = new DateTimePicker();
            button1 = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Lchoosemonth
            // 
            Lchoosemonth.AutoSize = true;
            Lchoosemonth.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            Lchoosemonth.Location = new Point(268, 38);
            Lchoosemonth.Name = "Lchoosemonth";
            Lchoosemonth.Size = new Size(135, 20);
            Lchoosemonth.TabIndex = 0;
            Lchoosemonth.Text = "选择月份按月汇总：";
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(1, 1);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 3;
            Ltitile.Text = "月报表";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dateTimePickerMonth
            // 
            dateTimePickerMonth.Location = new Point(401, 37);
            dateTimePickerMonth.Name = "dateTimePickerMonth";
            dateTimePickerMonth.Size = new Size(116, 23);
            dateTimePickerMonth.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(523, 35);
            button1.Name = "button1";
            button1.Size = new Size(80, 26);
            button1.TabIndex = 5;
            button1.Text = "汇总";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(12, 74);
            label1.Name = "label1";
            label1.Size = new Size(960, 35);
            label1.TabIndex = 6;
            label1.Text = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(969, 583);
            dataGridView1.TabIndex = 7;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(609, 35);
            button2.Name = "button2";
            button2.Size = new Size(121, 26);
            button2.TabIndex = 8;
            button2.Text = "生成Excel月报表";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // MonthlyReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dateTimePickerMonth);
            Controls.Add(Ltitile);
            Controls.Add(Lchoosemonth);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MonthlyReportForm";
            Text = "MonthlyReportForm";
            WindowState = FormWindowState.Maximized;
            Load += MonthlyReportForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Lchoosemonth;
        private Label Ltitile;
        private DateTimePicker dateTimePickerMonth;
        private Button button1;
        private Label label1;
        private DataGridView dataGridView1;
        private Button button2;
    }
}