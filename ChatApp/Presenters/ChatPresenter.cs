using ChatApp.Services;
using ChatApp.Views;
using ChatMessage = ChatApp.Models.Message;

namespace ChatApp.Presenters
{
    public class ChatPresenter
    {
        // --- FIELDS ---
        private readonly IMainView _view;
        private readonly ChatService _chatService;
        private string _username => _view.Username.Trim();

        // --- CONSTRUCTOR ---
        public ChatPresenter(IMainView view)
        {
            _view = view;
            _chatService = new ChatService();

            // Subscribe to View events
            _view.SendMessageRequested += OnSendMessageRequested;
            _view.HostRequested += OnHostRequested;
            _view.JoinRequested += OnJoinRequested;

            // Subscribe to ChatService events
            _chatService.Connected += OnConnected;
            _chatService.Disconnected += OnDisconnected;
            _chatService.MessageReceived += OnMessageReceived;
            _chatService.ErrorOccurred += OnErrorOccurred;
        }

        // --- VIEW EVENT HANDLERS ---

        private async void OnHostRequested(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_username))
            {
                _view.ShowWarning("Please enter a username before hosting.");
                return;
            }

            _view.UpdateStatus("Waiting for connection...", false);
            _view.SetOnlineIndicator(OnlineStatus.Waiting);
            _view.SetConnectionControlsEnabled(false);
            _view.ShowIpInput(false);

            await _chatService.StartHostingAsync(5000);
        }

        private async void OnJoinRequested(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_username))
            {
                _view.ShowWarning("Please enter a username before joining.");
                return;
            }

            string ip = _view.IpAddress.Trim();

            if (string.IsNullOrEmpty(ip))
            {
                _view.ShowIpInput(true);
                _view.UpdateStatus("Enter host IP then click Join", false);
                _view.SetOnlineIndicator(OnlineStatus.Waiting);
                return;
            }

            _view.UpdateStatus($"Connecting to {ip}...", false);
            _view.SetOnlineIndicator(OnlineStatus.Waiting);
            _view.SetConnectionControlsEnabled(false);

            await _chatService.JoinAsync(ip, 5000);
        }

        private async void OnSendMessageRequested(object? sender, EventArgs e)
        {
            string content = _view.MessageInput.Trim();

            if (string.IsNullOrEmpty(_username))
            {
                _view.ShowWarning("Please enter a username.");
                return;
            }

            if (string.IsNullOrEmpty(content))
            {
                _view.ShowWarning("Please type a message before sending.");
                return;
            }

            var message = new ChatMessage(_username, content);
            string formatted = message.ToDisplayString();

            await _chatService.SendMessageAsync(formatted);

            // Show our own message in blue
            _view.DisplayMessage(formatted, MessageType.Sent);
            _view.ClearMessageInput();
            _view.ScrollToBottom();
        }

        // --- CHATSERVICE EVENT HANDLERS ---

        private void OnConnected()
        {
            _view.UpdateStatus("Connected", true);
            _view.SetOnlineIndicator(OnlineStatus.Online);
            _view.SetChatControlsEnabled(true);
            _view.DisplayMessage("──────────────────────────────", MessageType.System);
            _view.DisplayMessage("  Connected! You can now chat.", MessageType.System);
            _view.DisplayMessage("──────────────────────────────", MessageType.System);
            _view.ScrollToBottom();
        }

        private void OnDisconnected()
        {
            _view.UpdateStatus("Disconnected", false);
            _view.SetOnlineIndicator(OnlineStatus.Offline);
            _view.SetChatControlsEnabled(false);
            _view.SetConnectionControlsEnabled(true);
            _view.DisplayMessage("──────────────────────────────", MessageType.System);
            _view.DisplayMessage("  Connection lost.", MessageType.System);
            _view.DisplayMessage("──────────────────────────────", MessageType.System);
            _view.ScrollToBottom();
        }

        private void OnMessageReceived(string message)
        {
            // Show received message in green
            _view.DisplayMessage(message, MessageType.Received);
            _view.ScrollToBottom();
        }

        private void OnErrorOccurred(string errorMessage)
        {
            _view.ShowWarning(errorMessage);
            _view.UpdateStatus("Not Connected", false);
            _view.SetOnlineIndicator(OnlineStatus.Offline);
            _view.SetConnectionControlsEnabled(true);
        }
    }
}