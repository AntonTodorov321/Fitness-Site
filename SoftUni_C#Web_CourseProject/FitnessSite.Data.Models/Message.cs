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

        public string SenderFirstName { get; set; } = null!;

        public string SenderLastName { get; set; } = null!;

        [MaxLength(QuestionMaxLength)]
        public string? Questions { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}