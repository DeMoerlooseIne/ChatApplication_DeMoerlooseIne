namespace ChatApplication.Models
{
    public class ChatMessageRequest
    {
        public string Author { get; set; }

        public string Message { get; set; }

        public string Channel { get; set; }
    }
}
