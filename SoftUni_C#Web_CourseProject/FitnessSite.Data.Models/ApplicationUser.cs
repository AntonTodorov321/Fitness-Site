namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            Messages = new HashSet<Message>();
        }

        [ForeignKey(nameof(Trainer))]
        public Guid? TrainerId { get; set; }

        public Trainer? Trainer { get; set; }


        [ForeignKey(nameof(Training))]
        public Guid? TrainingId { get; set; }

        public Training? Training { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
