namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;
    using static Common.EntityValidationsConstants.User;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            Id = Guid.NewGuid();
            Messages = new HashSet<Message>();
        }

        [ForeignKey(nameof(Trainer))]
        public Guid? TrainerId { get; set; }

        public Trainer? Trainer { get; set; }


        [ForeignKey(nameof(Training))]
        public Guid? TrainingId { get; set; }

        public Training? Training { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
    }
}