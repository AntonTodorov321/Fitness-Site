namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Message;

    public class Message
    {
        public Message()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [MaxLength(FirstNameMaxLength)]
        public string SenderFirstName { get; set; } = null!;

        [MaxLength(LastNameMaxLength)]
        public string SenderLastName { get; set; } = null!;

        public string? Questions { get; set; }

        public string? Description { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}
