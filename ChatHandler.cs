namespace ChatApp
{
    public class ChatHandler : WebSocketHandler
    {
        public ChatHandler(ConnectionManager connectionManager) : base(connectionManager)
        {
        }
    }
}