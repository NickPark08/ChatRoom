using System.Drawing;

namespace ChatRoom
{
    public class Message
    {
        public string MessageContent { get; set; }

        public ConsoleColor User {  get; set; }

        public Guid RoomID { get; set; }



        public Message(string message, ConsoleColor color, Guid roomID)
        {
            MessageContent = message;
            User = color;
            RoomID = roomID;
        }

        public Message()
        {
        }
    }
}
