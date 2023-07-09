namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.TypeExercise;

    public class TypeExercise
    {
        public TypeExercise()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLenght)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
