namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityValidationsConstants.Exercise;

    public class Exercise
    {
        public Exercise()
        {
            MuscleExercises = new HashSet<MuscleExercise>();
            TrainingExercises = new HashSet<TrainingExercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;


        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public virtual TypeExercise Type { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLenght)]
        public string Description { get; set; } = null!;

        public string? Reps { get; set; }

        public string? Sets { get; set; }

        [Required]
        [MaxLength(2048)]
        public string ImageUrl { get; set; } = null!;

        public int? Kilogram { get; set; }

        public virtual ICollection<MuscleExercise> MuscleExercises { get; set; }

        public virtual ICollection<TrainingExercise> TrainingExercises { get; set; }

    }
}
