namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TrainingExercise
    {
        [ForeignKey(nameof(Training))]
        public Guid? TrainingId { get; set; }

        public virtual Training? Training { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public virtual Exercise Esercise { get; set; } = null!;
    }
}
