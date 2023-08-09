namespace FitnessSite.Web.ViewModels.Exercise
{
    using System.ComponentModel.DataAnnotations;

    using TypeExercise;
    using static Common.EntityValidationsConstants.Exercise;

    public class EditGlobalExerciseViewModel : EditExerciseViewModel
    {
        public EditGlobalExerciseViewModel()
        {
            AllTypes = new HashSet<TypeExerciseViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength = DescriptionMinLength)]
        public string ImageUrl { get; set; } = null!;

        public int TypeId { get; set; }

        public ICollection<TypeExerciseViewModel> AllTypes { get; set; } = null!;
    }
}
