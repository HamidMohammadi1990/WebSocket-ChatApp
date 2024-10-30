namespace ChatApp
{
    public class ClientMessage
    {
        public string Type { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Content { get; set; }
        public bool? IsPrivate { get; set; }

        public bool IsValid(string expectedUsername)
        {
            if (IsTypeConnection())
            {
                if (Sender == string.Empty)
                {
                    return false;
                }
            }
            else if (IsTypeChat())
            {
                if (Sender != expectedUsername || Content == string.Empty)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public string BuildChatMessageBody()
        {
            string receiver = Receiver == string.Empty ? "Everybody" : this.Receiver;
            return $"{Sender} to {receiver}: {Content}";
        }

        public string GetMessageType()
        {
            return Type.ToUpper();
        }

        public bool IsTypeConnection()
        {
            return GetMessageType() == MessageType.CONNECTION.ToString();
        }

        public bool IsTypeChat()
        {
            return GetMessageType() == MessageType.CHAT.ToString();
        }
    }

    public enum MessageType { CONNECTION, CHAT }
}