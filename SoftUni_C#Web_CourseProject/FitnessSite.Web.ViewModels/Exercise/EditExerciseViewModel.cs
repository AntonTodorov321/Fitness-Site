namespace FitnessSite.Web.ViewModels.Exercise
{
    using System.ComponentModel.DataAnnotations;

    public class EditExerciseViewModel
    {
        public Guid Id { get; set; }

        [RegularExpression(@"(^\d{1,2} - \d{1,2}$|^\d{1,2}$)",
            ErrorMessage = "Reps must be in format dd or dd - dd")]
        public string? Reps { get; set; }

        [RegularExpression(@"(^\d{1,2} - \d{1,2}$|^\d{1,2}$)",
              ErrorMessage = "Sets must be in format dd or dd - dd")]
        public string? Sets { get; set; }

        [Display(Name = "Kg")]
        [Range(1,500)]
        public int? Kilogram { get; set; }
    }
}
