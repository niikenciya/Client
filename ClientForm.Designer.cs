namespace Client
{
    partial class ClientForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.ipTxt = new System.Windows.Forms.TextBox();
            this.portTxt = new System.Windows.Forms.TextBox();
            this.userNameTxt = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.chatViwer = new System.Windows.Forms.RichTextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.messageTxt = new System.Windows.Forms.TextBox();
            this.loaderImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loaderImg)).BeginInit();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipLabel.ForeColor = System.Drawing.Color.White;
            this.ipLabel.Location = new System.Drawing.Point(13, 12);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(123, 27);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "Ip сервера:";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portLabel.ForeColor = System.Drawing.Color.White;
            this.portLabel.Location = new System.Drawing.Point(13, 49);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(154, 27);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Порт сервера:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLabel.ForeColor = System.Drawing.Color.White;
            this.userNameLabel.Location = new System.Drawing.Point(13, 85);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(112, 27);
            this.userNameLabel.TabIndex = 4;
            this.userNameLabel.Text = "Никнейм:";
            // 
            // ipTxt
            // 
            this.ipTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ipTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ipTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ipTxt.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ipTxt.ForeColor = System.Drawing.Color.White;
            this.ipTxt.Location = new System.Drawing.Point(189, 13);
            this.ipTxt.Name = "ipTxt";
            this.ipTxt.Size = new System.Drawing.Size(182, 28);
            this.ipTxt.TabIndex = 1;
            this.ipTxt.Text = "127.0.0.1";
            // 
            // portTxt
            // 
            this.portTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.portTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.portTxt.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.portTxt.ForeColor = System.Drawing.Color.White;
            this.portTxt.Location = new System.Drawing.Point(189, 49);
            this.portTxt.Name = "portTxt";
            this.portTxt.Size = new System.Drawing.Size(182, 28);
            this.portTxt.TabIndex = 3;
            this.portTxt.Text = "5555";
            // 
            // userNameTxt
            // 
            this.userNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.userNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userNameTxt.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameTxt.ForeColor = System.Drawing.Color.White;
            this.userNameTxt.Location = new System.Drawing.Point(189, 85);
            this.userNameTxt.Name = "userNameTxt";
            this.userNameTxt.Size = new System.Drawing.Size(182, 28);
            this.userNameTxt.TabIndex = 5;
            this.userNameTxt.Text = "GRA";
            // 
            // connectButton
            // 
            this.connectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.connectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.connectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.connectButton.FlatAppearance.BorderSize = 0;
            this.connectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.connectButton.Location = new System.Drawing.Point(238, 121);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(133, 28);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = false;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // chatViwer
            // 
            this.chatViwer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatViwer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.chatViwer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatViwer.Enabled = false;
            this.chatViwer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatViwer.ForeColor = System.Drawing.Color.White;
            this.chatViwer.Location = new System.Drawing.Point(13, 13);
            this.chatViwer.Name = "chatViwer";
            this.chatViwer.ReadOnly = true;
            this.chatViwer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.chatViwer.Size = new System.Drawing.Size(358, 22);
            this.chatViwer.TabIndex = 7;
            this.chatViwer.TabStop = false;
            this.chatViwer.Text = "";
            this.chatViwer.Visible = false;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.sendButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.sendButton.Enabled = false;
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.sendButton.Location = new System.Drawing.Point(238, 121);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(133, 28);
            this.sendButton.TabIndex = 8;
            this.sendButton.TabStop = false;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Visible = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // messageTxt
            // 
            this.messageTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.messageTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageTxt.Enabled = false;
            this.messageTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageTxt.ForeColor = System.Drawing.Color.White;
            this.messageTxt.Location = new System.Drawing.Point(13, 41);
            this.messageTxt.Multiline = true;
            this.messageTxt.Name = "messageTxt";
            this.messageTxt.Size = new System.Drawing.Size(358, 73);
            this.messageTxt.TabIndex = 9;
            this.messageTxt.TabStop = false;
            this.messageTxt.Visible = false;
            // 
            // loaderImg
            // 
            this.loaderImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loaderImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loaderImg.Enabled = false;
            this.loaderImg.Image = ((System.Drawing.Image)(resources.GetObject("loaderImg.Image")));
            this.loaderImg.Location = new System.Drawing.Point(0, 0);
            this.loaderImg.Name = "loaderImg";
            this.loaderImg.Size = new System.Drawing.Size(382, 160);
            this.loaderImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loaderImg.TabIndex = 10;
            this.loaderImg.TabStop = false;
            this.loaderImg.Visible = false;
            // 
            // ClientForm
            // 
            this.AcceptButton = this.connectButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.loaderImg);
            this.Controls.Add(this.messageTxt);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.chatViwer);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.userNameTxt);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.portTxt);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipTxt);
            this.Controls.Add(this.ipLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "ClientForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.loaderImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox ipTxt;
        private System.Windows.Forms.TextBox portTxt;
        private System.Windows.Forms.TextBox userNameTxt;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox chatViwer;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox messageTxt;
        private System.Windows.Forms.PictureBox loaderImg;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label userNameLabel;
    }
}

