namespace ChatApp.Models
{
    /// <summary>
    /// Represents a single chat message in the application.
    /// This is a pure data class — no logic, no UI concerns.
    /// </summary>
    public class Message
    {
        // The name of the person who sent the message
        public string Username { get; set; }

        // The actual text content of the message
        public string Content { get; set; }

        // The exact time the message was created
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Constructor — enforces that a Message always has
        /// a sender, content, and a timestamp from birth.
        /// </summary>
        public Message(string username, string content)
        {
            Username = username;
            Content = content;
            Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Returns a formatted string ready for display in the chat window.
        /// Example output: "[10:45] User1: Hello there!"
        /// </summary>
        public string ToDisplayString()
        {
            return $"[{Timestamp:HH:mm}] {Username}: {Content}";
        }
    }
}