//namespace FitnessSite.Data.Models
//{
//    using System.ComponentModel.DataAnnotations;

//    using static Common.EntityValidationsConstants.Muscle;

//    public class Muscle
//    {
//        public Muscle()
//        {
//            MuscleExercises = new HashSet<MuscleExercise>();
//        }

//        [Key]
//        public int Id { get; set; }

//        [Required]
//        [MaxLength(NameMaxLenght)]
//        public string Name { get; set; } = null!;


//        public virtual ICollection<MuscleExercise> MuscleExercises { get; set; }
//    }
//}
