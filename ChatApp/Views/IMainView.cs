namespace ChatApp.Views
{
    /// <summary>
    /// Defines the type of message being displayed.
    /// Used by the View to apply the correct color.
    /// </summary>
    public enum MessageType
    {
        Sent,       // Your own message — blue
        Received,   // Other user's message — green
        System      // Connection info — grey
    }

    /// <summary>
    /// The contract between the Presenter and the View.
    /// </summary>
    public interface IMainView
    {
        // --- PROPERTIES ---
        string Username { get; }
        string MessageInput { get; }
        string IpAddress { get; }

        // --- METHODS ---
        void DisplayMessage(string formattedMessage, MessageType type);
        void ClearMessageInput();
        void ScrollToBottom();
        void ShowWarning(string message);
        void UpdateStatus(string status, bool isConnected);
        void SetChatControlsEnabled(bool enabled);
        void SetConnectionControlsEnabled(bool enabled);
        void ShowIpInput(bool visible);
        void SetOnlineIndicator(OnlineStatus status);

        // --- EVENTS ---
        event EventHandler SendMessageRequested;
        event EventHandler HostRequested;
        event EventHandler JoinRequested;
    }

    /// <summary>
    /// Represents the current connection state
    /// for the online indicator dot.
    /// </summary>
    public enum OnlineStatus
    {
        Offline,    // Red dot
        Waiting,    // Yellow dot
        Online      // Green dot
    }
}