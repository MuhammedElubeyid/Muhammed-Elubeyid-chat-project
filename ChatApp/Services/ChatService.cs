using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatApp.Services
{
    /// <summary>
    /// Handles all TCP networking logic.
    /// The Presenter talks to this class only through
    /// methods and events — no socket code anywhere else.
    /// </summary>
    public class ChatService
    {
        // --- FIELDS ---

        private TcpListener? _listener;
        private TcpClient? _client;
        private NetworkStream? _stream;
        private CancellationTokenSource? _cts;
        private bool _isConnected = false;

        // --- EVENTS ---
        // The Presenter subscribes to these to know what is happening

        /// <summary>Fired when a message is received from the other user.</summary>
        public event Action<string>? MessageReceived;

        /// <summary>Fired when a connection is established successfully.</summary>
        public event Action? Connected;

        /// <summary>Fired when the connection is lost or closed.</summary>
        public event Action? Disconnected;

        /// <summary>Fired when any error occurs — passes the error message.</summary>
        public event Action<string>? ErrorOccurred;

        // --- PUBLIC METHODS ---

        /// <summary>
        /// Starts listening for an incoming connection on the given port.
        /// Called when the user clicks Host.
        /// </summary>
        public async Task StartHostingAsync(int port = 5000)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();

                // Wait for the other user to connect
                _client = await _listener.AcceptTcpClientAsync();
                _stream = _client.GetStream();
                _isConnected = true;

                // Tell the Presenter we are connected
                Connected?.Invoke();

                // Start listening for incoming messages
                _ = ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"Host error: {ex.Message}");
            }
        }

        /// <summary>
        /// Connects to a host at the given IP and port.
        /// Called when the user clicks Join.
        /// </summary>
        public async Task JoinAsync(string ipAddress, int port = 5000)
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ipAddress, port);
                _stream = _client.GetStream();
                _isConnected = true;

                // Tell the Presenter we are connected
                Connected?.Invoke();

                // Start listening for incoming messages
                _ = ReceiveMessagesAsync();
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"Join error: {ex.Message}");
            }
        }

        /// <summary>
        /// Sends a message string to the other user over TCP.
        /// Called by the Presenter when the user hits Send.
        /// </summary>
        public async Task SendMessageAsync(string message)
        {
            if (!_isConnected || _stream == null)
            {
                ErrorOccurred?.Invoke("Not connected. Cannot send message.");
                return;
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message);
                await _stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                ErrorOccurred?.Invoke($"Send error: {ex.Message}");
            }
        }

        /// <summary>
        /// Disconnects and cleans up all resources.
        /// </summary>
        public void Disconnect()
        {
            _isConnected = false;
            _cts?.Cancel();
            _stream?.Close();
            _client?.Close();
            _listener?.Stop();
            Disconnected?.Invoke();
        }

        // --- PRIVATE METHODS ---

        /// <summary>
        /// Runs in the background and continuously listens for
        /// incoming messages from the other user.
        /// Fires MessageReceived each time a message arrives.
        /// </summary>
        private async Task ReceiveMessagesAsync()
        {
            byte[] buffer = new byte[4096];

            try
            {
                while (_isConnected && _stream != null)
                {
                    int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                    {
                        // Connection was closed by the other side
                        Disconnected?.Invoke();
                        break;
                    }

                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    // Fire the event so the Presenter can handle it
                    MessageReceived?.Invoke(message);
                }
            }
            catch (Exception)
            {
                if (_isConnected)
                {
                    Disconnected?.Invoke();
                }
            }
        }
    }
}