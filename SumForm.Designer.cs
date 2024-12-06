namespace WMS
{
    partial class SumForm
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
            SuspendLayout();
            // 
            // Ltitile
            // 
            Ltitile.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            Ltitile.Location = new Point(1, 1);
            Ltitile.Name = "Ltitile";
            Ltitile.Size = new Size(210, 40);
            Ltitile.TabIndex = 5;
            Ltitile.Text = "汇总统计";
            Ltitile.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SumForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 705);
            ControlBox = false;
            Controls.Add(Ltitile);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SumForm";
            Text = "SumForm";
            Load += SumForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label Ltitile;
    }
}