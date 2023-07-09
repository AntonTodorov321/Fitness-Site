namespace FitnessSite.Web.ViewModels.Exercise
{

    public class AllExerciseViewModel
    {
        public AllExerciseViewModel()
        {
            TargetMuscle = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? Reps { get; set; }

        public string? Sets { get; set; }

        public string ImageUrl { get; set; } = null!;

        public List<string> TargetMuscle { get; set; }
    }
}
