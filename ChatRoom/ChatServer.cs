namespace ChatRoom
{
    public static class ChatServer
    {
        public static Dictionary<Guid, List<Message>> messages = [];

        public static void AddMessage(Message message, Guid roomID)
        {
            messages[roomID].Add(message);
        }
    }
}