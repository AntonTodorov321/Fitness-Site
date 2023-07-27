namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Trainer;

    public class Trainer
    {
        public Trainer()
        {
            Id = Guid.NewGuid();
            ApllicationUsers = new HashSet<ApplicationUser>();
            Messages = new HashSet<Message>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLengh)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLengh)]
        public string LastName { get; set; } = null!;

        public int Year { get; set; }

        public int StartedAt { get; set; }

        public decimal PricePerMonth { get; set; }

        [Required]
        [MaxLength(TelefoneMaxLenght)]
        public string TelefoneNumber { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLenght)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(ImageUrlMaxLenght)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLengh)]
        public string Description { get; set; } = null!;

        public virtual ICollection<ApplicationUser> ApllicationUsers { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
