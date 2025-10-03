namespace PCBS.UserControls
{
    partial class General
    {
        private System.Windows.Forms.ComboBox cbConnPort;
        private System.Windows.Forms.ComboBox cbConnType;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.TextBox tbFirmware;
        private System.Windows.Forms.TextBox tbSerial;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSetRawData;
        private System.Windows.Forms.Button btnGetRawData;
        private System.Windows.Forms.Label lblValueRaw;
        private System.Windows.Forms.Label lblKeyRaw;
        private System.Windows.Forms.Label lblHeaderRaw;
        private System.Windows.Forms.TextBox tbValueRaw;
        private System.Windows.Forms.TextBox tbCodeRaw;
        private System.Windows.Forms.Label lblCombined;
        private System.Windows.Forms.Button btnSendCombined;
        private System.Windows.Forms.TextBox tbCombinedRequest;
        private System.Windows.Forms.Label lblConnection;
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblValueRaw = new System.Windows.Forms.Label();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.lblKeyRaw = new System.Windows.Forms.Label();
            this.lblHeaderRaw = new System.Windows.Forms.Label();
            this.tbFirmware = new System.Windows.Forms.TextBox();
            this.btnGetRawData = new System.Windows.Forms.Button();
            this.lblCombined = new System.Windows.Forms.Label();
            this.btnSetRawData = new System.Windows.Forms.Button();
            this.tbCombinedRequest = new System.Windows.Forms.TextBox();
            this.tbValueRaw = new System.Windows.Forms.TextBox();
            this.tbCodeRaw = new System.Windows.Forms.TextBox();
            this.btnSendCombined = new System.Windows.Forms.Button();
            this.cbConnType = new System.Windows.Forms.ComboBox();
            this.cbConnPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tbCombinedResponse = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConnection.Location = new System.Drawing.Point(9, 10);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(250, 20);
            this.lblConnection.TabIndex = 20;
            this.lblConnection.Text = "Настройка подключения";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSerial
            // 
            this.lblSerial.Location = new System.Drawing.Point(9, 86);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(121, 13);
            this.lblSerial.TabIndex = 4;
            this.lblSerial.Text = "Заводской номер";
            this.lblSerial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValueRaw
            // 
            this.lblValueRaw.Location = new System.Drawing.Point(63, 145);
            this.lblValueRaw.Name = "lblValueRaw";
            this.lblValueRaw.Size = new System.Drawing.Size(196, 13);
            this.lblValueRaw.TabIndex = 13;
            this.lblValueRaw.Text = "Значение";
            this.lblValueRaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(9, 102);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.ReadOnly = true;
            this.tbSerial.Size = new System.Drawing.Size(121, 20);
            this.tbSerial.TabIndex = 6;
            // 
            // lblFirmware
            // 
            this.lblFirmware.Location = new System.Drawing.Point(138, 86);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(121, 13);
            this.lblFirmware.TabIndex = 5;
            this.lblFirmware.Text = "Версия прошивки";
            this.lblFirmware.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKeyRaw
            // 
            this.lblKeyRaw.Location = new System.Drawing.Point(9, 145);
            this.lblKeyRaw.Name = "lblKeyRaw";
            this.lblKeyRaw.Size = new System.Drawing.Size(46, 13);
            this.lblKeyRaw.TabIndex = 12;
            this.lblKeyRaw.Text = "Код";
            this.lblKeyRaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderRaw
            // 
            this.lblHeaderRaw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblHeaderRaw.Location = new System.Drawing.Point(9, 125);
            this.lblHeaderRaw.Name = "lblHeaderRaw";
            this.lblHeaderRaw.Size = new System.Drawing.Size(250, 20);
            this.lblHeaderRaw.TabIndex = 11;
            this.lblHeaderRaw.Text = "Ручная отправка команд";
            this.lblHeaderRaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFirmware
            // 
            this.tbFirmware.Location = new System.Drawing.Point(138, 102);
            this.tbFirmware.Name = "tbFirmware";
            this.tbFirmware.ReadOnly = true;
            this.tbFirmware.Size = new System.Drawing.Size(121, 20);
            this.tbFirmware.TabIndex = 7;
            // 
            // btnGetRawData
            // 
            this.btnGetRawData.Location = new System.Drawing.Point(54, 187);
            this.btnGetRawData.Name = "btnGetRawData";
            this.btnGetRawData.Size = new System.Drawing.Size(89, 23);
            this.btnGetRawData.TabIndex = 14;
            this.btnGetRawData.Text = "Считать";
            this.btnGetRawData.UseVisualStyleBackColor = true;
            this.btnGetRawData.Click += new System.EventHandler(this.PullRawValue);
            // 
            // lblCombined
            // 
            this.lblCombined.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCombined.Location = new System.Drawing.Point(9, 213);
            this.lblCombined.Name = "lblCombined";
            this.lblCombined.Size = new System.Drawing.Size(250, 20);
            this.lblCombined.TabIndex = 16;
            this.lblCombined.Text = "Отправка составных команд";
            this.lblCombined.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSetRawData
            // 
            this.btnSetRawData.Location = new System.Drawing.Point(149, 187);
            this.btnSetRawData.Name = "btnSetRawData";
            this.btnSetRawData.Size = new System.Drawing.Size(110, 23);
            this.btnSetRawData.TabIndex = 15;
            this.btnSetRawData.Text = "Установить";
            this.btnSetRawData.UseVisualStyleBackColor = true;
            this.btnSetRawData.Click += new System.EventHandler(this.PushRawValue);
            // 
            // tbCombinedRequest
            // 
            this.tbCombinedRequest.Location = new System.Drawing.Point(9, 236);
            this.tbCombinedRequest.Name = "tbCombinedRequest";
            this.tbCombinedRequest.Size = new System.Drawing.Size(155, 20);
            this.tbCombinedRequest.TabIndex = 17;
            this.tbCombinedRequest.Text = "1";
            // 
            // tbValueRaw
            // 
            this.tbValueRaw.Location = new System.Drawing.Point(63, 161);
            this.tbValueRaw.Name = "tbValueRaw";
            this.tbValueRaw.Size = new System.Drawing.Size(196, 20);
            this.tbValueRaw.TabIndex = 10;
            this.tbValueRaw.Text = "1";
            // 
            // tbCodeRaw
            // 
            this.tbCodeRaw.Location = new System.Drawing.Point(9, 161);
            this.tbCodeRaw.MaxLength = 6;
            this.tbCodeRaw.Name = "tbCodeRaw";
            this.tbCodeRaw.Size = new System.Drawing.Size(46, 20);
            this.tbCodeRaw.TabIndex = 9;
            this.tbCodeRaw.Text = "800001";
            this.tbCodeRaw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSendCombined
            // 
            this.btnSendCombined.Location = new System.Drawing.Point(170, 236);
            this.btnSendCombined.Name = "btnSendCombined";
            this.btnSendCombined.Size = new System.Drawing.Size(89, 20);
            this.btnSendCombined.TabIndex = 18;
            this.btnSendCombined.Text = "Отправить";
            this.btnSendCombined.UseVisualStyleBackColor = true;
            this.btnSendCombined.Click += new System.EventHandler(this.SendCombinedCommand);
            // 
            // cbConnType
            // 
            this.cbConnType.FormattingEnabled = true;
            this.cbConnType.Items.AddRange(new object[] {
            "USB-HID",
            "USB-COM"});
            this.cbConnType.Location = new System.Drawing.Point(9, 33);
            this.cbConnType.Name = "cbConnType";
            this.cbConnType.Size = new System.Drawing.Size(75, 21);
            this.cbConnType.TabIndex = 1;
            this.cbConnType.Text = "USB-COM";
            this.cbConnType.SelectedIndexChanged += new System.EventHandler(this.OnChangedConnType);
            // 
            // cbConnPort
            // 
            this.cbConnPort.FormattingEnabled = true;
            this.cbConnPort.Location = new System.Drawing.Point(94, 33);
            this.cbConnPort.Name = "cbConnPort";
            this.cbConnPort.Size = new System.Drawing.Size(165, 21);
            this.cbConnPort.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(149, 60);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(110, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Подключиться";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.Connect);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(53, 60);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.RefreshConnTypes);
            // 
            // tbCombinedResponse
            // 
            this.tbCombinedResponse.Location = new System.Drawing.Point(9, 262);
            this.tbCombinedResponse.Name = "tbCombinedResponse";
            this.tbCombinedResponse.ReadOnly = true;
            this.tbCombinedResponse.Size = new System.Drawing.Size(250, 174);
            this.tbCombinedResponse.TabIndex = 22;
            this.tbCombinedResponse.Text = "";
            // 
            // General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbCombinedResponse);
            this.Controls.Add(this.lblConnection);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.lblValueRaw);
            this.Controls.Add(this.tbSerial);
            this.Controls.Add(this.lblFirmware);
            this.Controls.Add(this.lblKeyRaw);
            this.Controls.Add(this.lblHeaderRaw);
            this.Controls.Add(this.tbFirmware);
            this.Controls.Add(this.btnGetRawData);
            this.Controls.Add(this.lblCombined);
            this.Controls.Add(this.btnSetRawData);
            this.Controls.Add(this.tbCombinedRequest);
            this.Controls.Add(this.tbValueRaw);
            this.Controls.Add(this.tbCodeRaw);
            this.Controls.Add(this.btnSendCombined);
            this.Controls.Add(this.cbConnType);
            this.Controls.Add(this.cbConnPort);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnRefresh);
            this.MaximumSize = new System.Drawing.Size(268, 449);
            this.MinimumSize = new System.Drawing.Size(268, 449);
            this.Name = "General";
            this.Size = new System.Drawing.Size(268, 449);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbCombinedResponse;
    }
}
