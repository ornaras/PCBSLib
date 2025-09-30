namespace PCBS.UserControls
{
    partial class Visual
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbSoundStart = new System.Windows.Forms.CheckBox();
            this.nbFrequence = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSoundVolume = new System.Windows.Forms.ComboBox();
            this.cbSoundClick = new System.Windows.Forms.CheckBox();
            this.cbSoundSuccess = new System.Windows.Forms.CheckBox();
            this.cbBackLight = new System.Windows.Forms.CheckBox();
            this.cbLedSuccess = new System.Windows.Forms.CheckBox();
            this.nbFrequenceError = new System.Windows.Forms.NumericUpDown();
            this.cbSoundDuration = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nbFrequence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbFrequenceError)).BeginInit();
            this.SuspendLayout();
            // 
            // cbSoundStart
            // 
            this.cbSoundStart.AutoSize = true;
            this.cbSoundStart.Location = new System.Drawing.Point(3, 32);
            this.cbSoundStart.Name = "cbSoundStart";
            this.cbSoundStart.Size = new System.Drawing.Size(243, 17);
            this.cbSoundStart.TabIndex = 1;
            this.cbSoundStart.Tag = "841013";
            this.cbSoundStart.Text = "Активировать звуковой сигнал при старте";
            this.cbSoundStart.UseVisualStyleBackColor = true;
            // 
            // nbFrequence
            // 
            this.nbFrequence.Location = new System.Drawing.Point(159, 201);
            this.nbFrequence.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nbFrequence.Name = "nbFrequence";
            this.nbFrequence.Size = new System.Drawing.Size(121, 20);
            this.nbFrequence.TabIndex = 2;
            this.nbFrequence.Tag = "841006";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Громкость звуковых сигналов";
            // 
            // cbSoundVolume
            // 
            this.cbSoundVolume.FormattingEnabled = true;
            this.cbSoundVolume.Items.AddRange(new object[] {
            "Отключить",
            "Низкая",
            "Средняя",
            "Высокая"});
            this.cbSoundVolume.Location = new System.Drawing.Point(172, 147);
            this.cbSoundVolume.Name = "cbSoundVolume";
            this.cbSoundVolume.Size = new System.Drawing.Size(120, 21);
            this.cbSoundVolume.TabIndex = 4;
            this.cbSoundVolume.Tag = "841009";
            // 
            // cbSoundClick
            // 
            this.cbSoundClick.AutoSize = true;
            this.cbSoundClick.Location = new System.Drawing.Point(3, 55);
            this.cbSoundClick.Name = "cbSoundClick";
            this.cbSoundClick.Size = new System.Drawing.Size(302, 17);
            this.cbSoundClick.TabIndex = 6;
            this.cbSoundClick.Tag = "841014";
            this.cbSoundClick.Text = "Активировать звуковой щелчок при нажатии на курок";
            this.cbSoundClick.UseVisualStyleBackColor = true;
            // 
            // cbSoundSuccess
            // 
            this.cbSoundSuccess.AutoSize = true;
            this.cbSoundSuccess.Location = new System.Drawing.Point(3, 78);
            this.cbSoundSuccess.Name = "cbSoundSuccess";
            this.cbSoundSuccess.Size = new System.Drawing.Size(305, 17);
            this.cbSoundSuccess.TabIndex = 7;
            this.cbSoundSuccess.Tag = "841001";
            this.cbSoundSuccess.Text = "Активировать звуковой сигнал успешного считывания";
            this.cbSoundSuccess.UseVisualStyleBackColor = true;
            // 
            // cbBackLight
            // 
            this.cbBackLight.AutoSize = true;
            this.cbBackLight.Location = new System.Drawing.Point(3, 101);
            this.cbBackLight.Name = "cbBackLight";
            this.cbBackLight.Size = new System.Drawing.Size(209, 17);
            this.cbBackLight.TabIndex = 8;
            this.cbBackLight.Tag = "898005";
            this.cbBackLight.Text = "Активировать подсветку штрихкода";
            this.cbBackLight.UseVisualStyleBackColor = true;
            // 
            // cbLedSuccess
            // 
            this.cbLedSuccess.AutoSize = true;
            this.cbLedSuccess.Location = new System.Drawing.Point(3, 124);
            this.cbLedSuccess.Name = "cbLedSuccess";
            this.cbLedSuccess.Size = new System.Drawing.Size(279, 17);
            this.cbLedSuccess.TabIndex = 9;
            this.cbLedSuccess.Tag = "841008";
            this.cbLedSuccess.Text = "Активировать LED-сигнал успешного считывания";
            this.cbLedSuccess.UseVisualStyleBackColor = true;
            // 
            // nbFrequenceError
            // 
            this.nbFrequenceError.Location = new System.Drawing.Point(240, 227);
            this.nbFrequenceError.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nbFrequenceError.Name = "nbFrequenceError";
            this.nbFrequenceError.Size = new System.Drawing.Size(120, 20);
            this.nbFrequenceError.TabIndex = 11;
            this.nbFrequenceError.Tag = "841007";
            // 
            // cbSoundDuration
            // 
            this.cbSoundDuration.FormattingEnabled = true;
            this.cbSoundDuration.Items.AddRange(new object[] {
            "По-умолчанию",
            "Короткий"});
            this.cbSoundDuration.Location = new System.Drawing.Point(287, 174);
            this.cbSoundDuration.Name = "cbSoundDuration";
            this.cbSoundDuration.Size = new System.Drawing.Size(123, 21);
            this.cbSoundDuration.TabIndex = 12;
            this.cbSoundDuration.Tag = "841002";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Длительность сигнала успешного считывания кодов";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Частота звуковых сигналов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Частота сигнала ошибки считывания кодов";
            // 
            // Visual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSoundDuration);
            this.Controls.Add(this.nbFrequenceError);
            this.Controls.Add(this.cbLedSuccess);
            this.Controls.Add(this.cbBackLight);
            this.Controls.Add(this.cbSoundSuccess);
            this.Controls.Add(this.cbSoundClick);
            this.Controls.Add(this.cbSoundVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nbFrequence);
            this.Controls.Add(this.cbSoundStart);
            this.Name = "Visual";
            this.Size = new System.Drawing.Size(410, 247);
            ((System.ComponentModel.ISupportInitialize)(this.nbFrequence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbFrequenceError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSoundStart;
        private System.Windows.Forms.NumericUpDown nbFrequence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSoundVolume;
        private System.Windows.Forms.CheckBox cbSoundClick;
        private System.Windows.Forms.CheckBox cbSoundSuccess;
        private System.Windows.Forms.CheckBox cbBackLight;
        private System.Windows.Forms.CheckBox cbLedSuccess;
        private System.Windows.Forms.NumericUpDown nbFrequenceError;
        private System.Windows.Forms.ComboBox cbSoundDuration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}
