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
            this.visual = new PCBS.UserControls.Visual();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageVisual = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
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
            // visual
            // 
            this.visual.Location = new System.Drawing.Point(0, 0);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.pageVisual);
            this.tabControl.Location = new System.Drawing.Point(268, 12);
            this.tabControl.Name = "tabControl1";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(608, 425);
            this.tabControl.TabIndex = 22;
            // 
            // pageVisual
            // 
            this.pageVisual.Controls.Add(this.visual);
            this.pageVisual.Location = new System.Drawing.Point(4, 22);
            this.pageVisual.Name = "pageVisual";
            this.pageVisual.Padding = new System.Windows.Forms.Padding(3);
            this.pageVisual.Size = new System.Drawing.Size(600, 399);
            this.pageVisual.TabIndex = 0;
            this.pageVisual.Text = "Звук и индикация";
            this.pageVisual.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 449);
            this.Controls.Add(this.general);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Тест бибилиотеки PCBSLib";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageVisual;
        private PCBS.UserControls.General general;
        private PCBS.UserControls.Visual visual;
    }
}