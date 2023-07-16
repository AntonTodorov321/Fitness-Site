namespace FitnessSite.Web.ViewModels.Exercise
{
    using FitnessSite.Web.ViewModels.Training;

    public class AllExerciseViewModel
    {
        public AllExerciseViewModel()
        {
            TargetMuscle = new List<string>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Reps { get; set; }

        public string? Sets { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int? Kilograms { get; set; }

        public List<string> TargetMuscle { get; set; }

    }
}
