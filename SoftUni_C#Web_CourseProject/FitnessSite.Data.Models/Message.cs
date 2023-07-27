namespace FitnessSite.Data.Models
{

    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string SenderFirstName { get; set; } = null!;
        public string SenderLastName { get; set; } = null!;

        public string? Questions { get; set; }

        public string? Description { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}
