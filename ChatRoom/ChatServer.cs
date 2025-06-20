namespace ChatRoom
{
    static class ChatServer
    {
        public static Dictionary<Guid, List<Message>> messages = [];

        public static void AddMessage(Message message, Guid roomID)
        {
            messages[roomID].Add(message);
        }

        //public static void AddRoom(Guid roomID)
        //{
        //    messages.Add(roomID, new List<Message>());
        //    ;
        //}
    }
}