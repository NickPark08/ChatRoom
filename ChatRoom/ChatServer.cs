namespace ChatRoom
{
    public static class ChatServer
    {
        public static List<Message> messages = [];

        public static void AddMessage(Message message)
        {
            messages.Add(message);
        }
    }
}