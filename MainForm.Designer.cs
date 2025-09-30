namespace PCBS
{
    partial class MainForm
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
            this.general = new PCBS.UserControls.General();
            this.SuspendLayout();
            // 
            // general
            // 
            this.general.Location = new System.Drawing.Point(12, 12);
            this.general.MaximumSize = new System.Drawing.Size(250, 246);
            this.general.MinimumSize = new System.Drawing.Size(250, 246);
            this.general.Name = "general";
            this.general.Size = new System.Drawing.Size(250, 246);
            this.general.TabIndex = 23;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 449);
            this.Controls.Add(this.general);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Тест бибилиотеки PCBSLib";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PCBS.UserControls.General general;
    }
}