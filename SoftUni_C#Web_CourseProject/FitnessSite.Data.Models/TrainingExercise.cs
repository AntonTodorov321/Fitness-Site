namespace FitnessSite.Data.Models
{
    public class TrainingExercise
    {
        public Guid TrainingId { get; set; }

        public virtual Training Training { get; set; } = null!;

        public int ExerciseId { get; set; }

        public virtual Exercise Esercise { get; set; } = null!;
    }
}
