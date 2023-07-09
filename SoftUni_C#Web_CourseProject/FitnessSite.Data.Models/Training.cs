namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Training
    {
        public Training()
        {
            Exercises = new HashSet<Exercise>();
            Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string TotalTime 
        {
            get
            {
                return this.Start.Subtract(End).Ticks.ToString("t");
            }
        }

        [ForeignKey(nameof(ApllicationUser))]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApllicationUser { get; set; } = null!;

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
