namespace FitnessSite.Web.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationsConstants.Message;

    public class SendMessageViewModel
    {
        public string SenderFirstName { get; set; } = null!;

        public string SenderLastName { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(QuestionMaxLength)]
        public string? Question { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}