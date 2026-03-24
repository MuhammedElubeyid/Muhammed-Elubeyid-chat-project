using ChatApp.Presenters;
using ChatApp.Views;

namespace ChatApp.Views
{
    public partial class MainForm : Form, IMainView
    {
        // --- FIELDS ---
        private ChatPresenter _presenter;

        // --- DARK THEME COLORS ---
        private readonly Color _darkBackground = Color.FromArgb(18, 18, 18);
        private readonly Color _darkSurface = Color.FromArgb(30, 30, 30);
        private readonly Color _darkInput = Color.FromArgb(40, 40, 40);
        private readonly Color _darkBorder = Color.FromArgb(60, 60, 60);
        private readonly Color _textPrimary = Color.FromArgb(220, 220, 220);
        private readonly Color _textSecondary = Color.FromArgb(140, 140, 140);
        private readonly Color _accentBlue = Color.FromArgb(41, 128, 185);
        private readonly Color _accentGreen = Color.FromArgb(39, 174, 96);
        private readonly Color _accentRed = Color.FromArgb(192, 57, 43);
        private readonly Color _accentYellow = Color.FromArgb(241, 196, 15);

        // --- MESSAGE COLORS ---
        private readonly Color _sentColor = Color.FromArgb(100, 180, 255);
        private readonly Color _receivedColor = Color.FromArgb(100, 220, 140);
        private readonly Color _systemColor = Color.FromArgb(120, 120, 120);

        // --- CONSTRUCTOR ---
        public MainForm()
        {
            InitializeComponent();
            _presenter = new ChatPresenter(this);

            ApplyDarkTheme();

            // Disable Send until user types
            txtMessage.TextChanged += (s, e) =>
                btnSend.Enabled = !string.IsNullOrWhiteSpace(txtMessage.Text);

            this.Load += (s, e) => txtMessage.Focus();

            DisplayWelcomeMessage();
        }

        /// <summary>
        /// Draws the online indicator as a circle instead of a square.
        /// Moved here from Designer because lambdas break the Designer parser.
        /// </summary>
        private void pnlIndicator_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            using var brush = new SolidBrush(pnlIndicator.BackColor);

            e.Graphics.FillEllipse(brush, 0, 0,
                pnlIndicator.Width - 1,
                pnlIndicator.Height - 1);
        }

        // =============================================
        // IMINVIEW PROPERTIES
        // =============================================

        public string Username => txtUsername.Text;
        public string MessageInput => txtMessage.Text;
        public string IpAddress => txtIpAddress.Text;

        // =============================================
        // IMAINVIEW METHODS
        // =============================================

        /// <summary>
        /// Appends a colored message to the chat display.
        /// Color is determined by the MessageType passed in.
        /// </summary>
        public void DisplayMessage(string formattedMessage, MessageType type)
        {
            if (rtbChatDisplay.InvokeRequired)
            {
                rtbChatDisplay.Invoke(() => DisplayMessage(formattedMessage, type));
                return;
            }

            // Pick the color based on message type
            Color messageColor = type switch
            {
                MessageType.Sent => _sentColor,
                MessageType.Received => _receivedColor,
                MessageType.System => _systemColor,
                _ => _textPrimary
            };

            // Move caret to end and set color before appending
            rtbChatDisplay.SelectionStart = rtbChatDisplay.TextLength;
            rtbChatDisplay.SelectionLength = 0;
            rtbChatDisplay.SelectionColor = messageColor;
            rtbChatDisplay.AppendText(formattedMessage + Environment.NewLine);
        }

        public void ClearMessageInput()
        {
            txtMessage.Clear();
        }

        public void ScrollToBottom()
        {
            if (rtbChatDisplay.InvokeRequired)
            {
                rtbChatDisplay.Invoke(ScrollToBottom);
                return;
            }

            rtbChatDisplay.SelectionStart = rtbChatDisplay.Text.Length;
            rtbChatDisplay.ScrollToCaret();
        }

        public void ShowWarning(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => ShowWarning(message));
                return;
            }

            MessageBox.Show(message, "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }

        public void UpdateStatus(string status, bool isConnected)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(() => UpdateStatus(status, isConnected));
                return;
            }

            lblStatus.Text = status;
            lblStatus.ForeColor = isConnected ? _accentGreen : _textSecondary;
        }

        public void SetChatControlsEnabled(bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => SetChatControlsEnabled(enabled));
                return;
            }

            txtMessage.Enabled = enabled;
            btnSend.Enabled = enabled &&
                !string.IsNullOrWhiteSpace(txtMessage.Text);
        }

        public void SetConnectionControlsEnabled(bool enabled)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => SetConnectionControlsEnabled(enabled));
                return;
            }

            btnHost.Enabled = enabled;
            btnJoin.Enabled = enabled;
        }

        public void ShowIpInput(bool visible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(() => ShowIpInput(visible));
                return;
            }

            txtIpAddress.Visible = visible;

            if (visible)
                txtIpAddress.Focus();
        }

        /// <summary>
        /// Updates the online indicator dot color.
        /// Red = offline, Yellow = waiting, Green = online.
        /// </summary>
        public void SetOnlineIndicator(OnlineStatus status)
        {
            if (pnlIndicator.InvokeRequired)
            {
                pnlIndicator.Invoke(() => SetOnlineIndicator(status));
                return;
            }

            pnlIndicator.BackColor = status switch
            {
                OnlineStatus.Online => _accentGreen,
                OnlineStatus.Waiting => _accentYellow,
                OnlineStatus.Offline => _accentRed,
                _ => _accentRed
            };

            pnlIndicator.Invalidate();
        }

        // =============================================
        // IMAINVIEW EVENTS
        // =============================================

        public event EventHandler SendMessageRequested;
        public event EventHandler HostRequested;
        public event EventHandler JoinRequested;

        // =============================================
        // UI EVENT HANDLERS
        // =============================================

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessageRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnHost_Click(object sender, EventArgs e)
        {
            HostRequested?.Invoke(this, EventArgs.Empty);
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            JoinRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Toggles the settings panel open and closed.
        /// Panel slides in from the right side of the form.
        /// </summary>
        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlSettings.Visible = !pnlSettings.Visible;
            btnSettings.Text = pnlSettings.Visible ? "✕ Close" : "⚙ Settings";

            // Always bring to front when opening
            if (pnlSettings.Visible)
                pnlSettings.BringToFront();
        }

        // =============================================
        // PRIVATE HELPERS
        // =============================================

        /// <summary>
        /// Applies dark theme colors to every control on the form.
        /// Called once in the constructor after InitializeComponent.
        /// </summary>
        private void ApplyDarkTheme()
        {
            // Form
            this.BackColor = _darkBackground;

            // Top bar
            lblUsername.ForeColor = _textPrimary;
            txtUsername.BackColor = _darkInput;
            txtUsername.ForeColor = _textPrimary;
            txtUsername.BorderStyle = BorderStyle.FixedSingle;

            // Settings button
            btnSettings.BackColor = _darkSurface;
            btnSettings.ForeColor = _textPrimary;
            btnSettings.FlatAppearance.BorderColor = _darkBorder;

            // Status bar
            lblStatus.ForeColor = _textSecondary;
            pnlIndicator.BackColor = _accentRed;

            // Chat display
            rtbChatDisplay.BackColor = _darkSurface;
            rtbChatDisplay.ForeColor = _textPrimary;
            rtbChatDisplay.BorderStyle = BorderStyle.None;

            // Message input
            txtMessage.BackColor = _darkInput;
            txtMessage.ForeColor = _textPrimary;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;

            // Send button
            btnSend.BackColor = _accentBlue;
            btnSend.FlatAppearance.BorderSize = 0;

            // Settings panel
            pnlSettings.BackColor = _darkSurface;
            lblSettingsTitle.ForeColor = _textPrimary;

            // Settings controls
            btnHost.BackColor = _accentGreen;
            btnHost.FlatAppearance.BorderSize = 0;
            btnJoin.BackColor = _accentBlue;
            btnJoin.FlatAppearance.BorderSize = 0;
            txtIpAddress.BackColor = _darkInput;
            txtIpAddress.ForeColor = _textPrimary;
            txtIpAddress.BorderStyle = BorderStyle.FixedSingle;

            // Status bar panel
            pnlStatusBar.BackColor = _darkSurface;
        }

        private void DisplayWelcomeMessage()
        {
            DisplayMessage("──────────────────────────────", MessageType.System);
            DisplayMessage("  Welcome to Chat App! 👋", MessageType.System);
            DisplayMessage("  Open ⚙ Settings to Host", MessageType.System);
            DisplayMessage("  or Join a chat session.", MessageType.System);
            DisplayMessage("──────────────────────────────", MessageType.System);
            DisplayMessage("", MessageType.System);
        }
    }
}