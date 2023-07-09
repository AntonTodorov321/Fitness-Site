namespace FitnessSite.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
         
            Exercises = new HashSet<Exercise>();
        }

        [ForeignKey(nameof(Trainer))]
        public int? TrainerId { get; set; }

        public Trainer? Trainer { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
