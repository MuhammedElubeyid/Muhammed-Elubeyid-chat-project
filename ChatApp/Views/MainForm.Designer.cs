namespace ChatApp.Views
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblUsername = new Label();
            txtUsername = new TextBox();
            btnSettings = new Button();
            pnlStatusBar = new Panel();
            pnlIndicator = new Panel();
            lblStatus = new Label();
            rtbChatDisplay = new RichTextBox();
            txtMessage = new TextBox();
            btnSend = new Button();
            pnlSettings = new Panel();
            lblSettingsTitle = new Label();
            lblDivider = new Label();
            btnHost = new Button();
            btnJoin = new Button();
            txtIpAddress = new TextBox();
            lblIpHint = new Label();
            pnlStatusBar.SuspendLayout();
            pnlSettings.SuspendLayout();
            SuspendLayout();
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9.5F);
            lblUsername.Location = new Point(12, 16);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 21);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Segoe UI", 9.5F);
            txtUsername.Location = new Point(102, 12);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 29);
            txtUsername.TabIndex = 1;
            txtUsername.Text = "User1";
            // 
            // btnSettings
            // 
            btnSettings.Cursor = Cursors.Hand;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSettings.Location = new Point(390, 10);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(105, 30);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "⚙ Settings";
            btnSettings.Click += btnSettings_Click;
            // 
            // pnlStatusBar
            // 
            pnlStatusBar.Controls.Add(pnlIndicator);
            pnlStatusBar.Controls.Add(lblStatus);
            pnlStatusBar.Location = new Point(0, 48);
            pnlStatusBar.Name = "pnlStatusBar";
            pnlStatusBar.Size = new Size(510, 32);
            pnlStatusBar.TabIndex = 3;
            // 
            // pnlIndicator
            // 
            pnlIndicator.Location = new Point(12, 10);
            pnlIndicator.Name = "pnlIndicator";
            pnlIndicator.Size = new Size(12, 12);
            pnlIndicator.TabIndex = 0;
            pnlIndicator.Paint += pnlIndicator_Paint;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblStatus.Location = new Point(30, 7);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(105, 20);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Not Connected";
            // 
            // rtbChatDisplay
            // 
            rtbChatDisplay.BorderStyle = BorderStyle.None;
            rtbChatDisplay.Font = new Font("Segoe UI", 10F);
            rtbChatDisplay.Location = new Point(0, 80);
            rtbChatDisplay.Name = "rtbChatDisplay";
            rtbChatDisplay.ReadOnly = true;
            rtbChatDisplay.ScrollBars = RichTextBoxScrollBars.Vertical;
            rtbChatDisplay.Size = new Size(510, 460);
            rtbChatDisplay.TabIndex = 4;
            rtbChatDisplay.Text = "";
            // 
            // txtMessage
            // 
            txtMessage.Enabled = false;
            txtMessage.Font = new Font("Segoe UI", 10F);
            txtMessage.Location = new Point(12, 552);
            txtMessage.Name = "txtMessage";
            txtMessage.PlaceholderText = "Type a message...";
            txtMessage.Size = new Size(360, 30);
            txtMessage.TabIndex = 5;
            // 
            // btnSend
            // 
            btnSend.Cursor = Cursors.Hand;
            btnSend.Enabled = false;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(380, 550);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(118, 32);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.Click += btnSend_Click;
            // 
            // pnlSettings
            // 
            pnlSettings.Controls.Add(lblSettingsTitle);
            pnlSettings.Controls.Add(lblDivider);
            pnlSettings.Controls.Add(btnHost);
            pnlSettings.Controls.Add(btnJoin);
            pnlSettings.Controls.Add(txtIpAddress);
            pnlSettings.Controls.Add(lblIpHint);
            pnlSettings.Location = new Point(260, 80);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(250, 320);
            pnlSettings.TabIndex = 7;
            pnlSettings.Visible = false;
            // 
            // lblSettingsTitle
            // 
            lblSettingsTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSettingsTitle.Location = new Point(0, 12);
            lblSettingsTitle.Name = "lblSettingsTitle";
            lblSettingsTitle.Size = new Size(250, 40);
            lblSettingsTitle.TabIndex = 0;
            lblSettingsTitle.Text = "⚙  Connection Settings";
            lblSettingsTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDivider
            // 
            lblDivider.BorderStyle = BorderStyle.Fixed3D;
            lblDivider.Location = new Point(15, 55);
            lblDivider.Name = "lblDivider";
            lblDivider.Size = new Size(220, 2);
            lblDivider.TabIndex = 1;
            // 
            // btnHost
            // 
            btnHost.Cursor = Cursors.Hand;
            btnHost.FlatStyle = FlatStyle.Flat;
            btnHost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHost.ForeColor = Color.White;
            btnHost.Location = new Point(25, 70);
            btnHost.Name = "btnHost";
            btnHost.Size = new Size(200, 42);
            btnHost.TabIndex = 2;
            btnHost.Text = "🖥  Host a Chat";
            btnHost.Click += btnHost_Click;
            // 
            // btnJoin
            // 
            btnJoin.Cursor = Cursors.Hand;
            btnJoin.FlatStyle = FlatStyle.Flat;
            btnJoin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnJoin.ForeColor = Color.White;
            btnJoin.Location = new Point(25, 125);
            btnJoin.Name = "btnJoin";
            btnJoin.Size = new Size(200, 42);
            btnJoin.TabIndex = 3;
            btnJoin.Text = "🔗  Join a Chat";
            btnJoin.Click += btnJoin_Click;
            // 
            // txtIpAddress
            // 
            txtIpAddress.Font = new Font("Segoe UI", 9.5F);
            txtIpAddress.Location = new Point(25, 182);
            txtIpAddress.Name = "txtIpAddress";
            txtIpAddress.PlaceholderText = "Enter host IP address...";
            txtIpAddress.Size = new Size(200, 29);
            txtIpAddress.TabIndex = 4;
            txtIpAddress.Visible = false;
            // 
            // lblIpHint
            // 
            lblIpHint.AutoSize = true;
            lblIpHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            lblIpHint.ForeColor = Color.FromArgb(140, 140, 140);
            lblIpHint.Location = new Point(25, 215);
            lblIpHint.Name = "lblIpHint";
            lblIpHint.Size = new Size(186, 19);
            lblIpHint.TabIndex = 5;
            lblIpHint.Text = "Type IP then click Join again";
            // 
            // MainForm
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(510, 595);
            Controls.Add(lblUsername);
            Controls.Add(txtUsername);
            Controls.Add(btnSettings);
            Controls.Add(pnlStatusBar);
            Controls.Add(rtbChatDisplay);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(pnlSettings);
            MaximizeBox = false;
            MinimumSize = new Size(526, 640);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat App";
            pnlStatusBar.ResumeLayout(false);
            pnlStatusBar.PerformLayout();
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        // --- CONTROL DECLARATIONS ---
        private Label lblUsername;
        private TextBox txtUsername;
        private Button btnSettings;
        private Panel pnlStatusBar;
        private Panel pnlIndicator;
        private Label lblStatus;
        private RichTextBox rtbChatDisplay;
        private TextBox txtMessage;
        private Button btnSend;
        private Panel pnlSettings;
        private Label lblSettingsTitle;
        private Button btnHost;
        private Button btnJoin;
        private TextBox txtIpAddress;
        private Label lblDivider;
        private Label lblIpHint;
    }
}