namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MuscleExercise
    {
        [ForeignKey(nameof(Muscle))]
        public int MuscleId { get; set; }

        public virtual Muscle Muscle { get; set; } = null!;


        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; } = null!;
    }
}
