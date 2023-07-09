namespace FitnessSite.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        [ForeignKey(nameof(Trainer))]
        public int? TrainerId { get; set; }

        public Trainer? Trainer { get; set; }


        [ForeignKey(nameof(Training))]
        public Guid? TrainingId { get; set; }

        public Training? Training { get; set; }
    }
}
