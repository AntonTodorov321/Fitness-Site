namespace FitnessSite.Web.ViewModels.Message
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Message;
    public class MessageViewModel
    {
        [StringLength(FirstNameMaxLengh, MinimumLength = FirstNameMinLengh)]
        public string SenderFirstName { get; set; } = null!;

        [StringLength(LastNameMaxLengh, MinimumLength = LastNameMinLengh)]
        public string SenderLastName { get; set; } = null!;

        public string? Description { get; set; }

        public string? Question { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecipientId { get; set; }
    }
}
