namespace FitnessSite.Web.Areas.Trainer.Models.Exercise
{
    using System.ComponentModel.DataAnnotations;

    using TypeExercise;
    using static Common.EntityValidationsConstants.Exercise;

    public class EditGlobalExerciseViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [RegularExpression(RepsRegularExpression, 
            ErrorMessage = RepsErrorMessage)]
        public string? Reps { get; set; }

        public string? Sets { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength,MinimumLength = DescriptionMinLength)]
        public string ImageUrl { get; set; } = null!;

        public int? Kilogram { get; set; }

        public int TypeId { get; set; }

        public ICollection<TypeExerciseViewModel> AllTypes { get; set; } = null!;
    }
}
