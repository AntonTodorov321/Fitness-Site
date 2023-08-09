namespace FitnessSite.Web.ViewModels.Exercise
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Exercise;

    public class EditExerciseViewModel
    {
        public Guid Id { get; set; }

        [RegularExpression(RepsRegularExpression,
            ErrorMessage = RepsErrorMessage)]
        public string? Reps { get; set; }

        [RegularExpression(SetsRegularExpression,
              ErrorMessage = SetsErrorMessage)]
        public string? Sets { get; set; }

        [Display(Name = "Kg")]
        [Range(1,500)]
        public int? Kilogram { get; set; }
    }
}
