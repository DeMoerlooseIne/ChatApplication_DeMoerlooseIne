namespace ChatApplication.Models
{
    public class ChatChannelResult
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
