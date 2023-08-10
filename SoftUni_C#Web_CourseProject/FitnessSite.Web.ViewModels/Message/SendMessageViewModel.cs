namespace FitnessSite.Web.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Message;
    public class SendMessageViewModel
    {
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        public string SenderFirstName { get; set; } = null!;

        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        public string SenderLastName { get; set; } = null!;

        public string? Description { get; set; }

        public string? Question { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}
