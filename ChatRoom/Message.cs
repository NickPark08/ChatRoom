using System.Drawing;

namespace ChatRoom
{
    public class Message
    {
        public string MessageContent { get; set; }

        public ConsoleColor User {  get; set; }



        public Message(string message, ConsoleColor color)
        {
            MessageContent = message;
            User = color;
        }

        public Message()
        {
        }
    }
}
