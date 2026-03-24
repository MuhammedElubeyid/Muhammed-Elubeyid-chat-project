namespace ChatApp.Models
{
    /// <summary>
    /// Represents an active chat session.
    /// Holds all messages exchanged during the session.
    /// Think of this as our in-memory "database" for now.
    /// </summary>
    public class ChatSession
    {
        // The full history of messages in this session
        public List<Message> Messages { get; private set; }

        public ChatSession()
        {
            Messages = new List<Message>();
        }

        /// <summary>
        /// Adds a new message to the session history.
        /// </summary>
        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }

        /// <summary>
        /// Returns the total number of messages sent so far.
        /// </summary>
        public int MessageCount => Messages.Count;
    }
}