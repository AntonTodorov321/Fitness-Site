namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Training
    {
        public Training()
        {
            TrainingExercises = new HashSet<TrainingExercise>();

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

        public bool IsStarted { get; set; }

        public bool IsEnded { get; set; }

        [ForeignKey(nameof(ApllicationUser))]
        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApllicationUser { get; set; } = null!;

        public virtual ICollection<TrainingExercise> TrainingExercises { get; set; }
    }
}
