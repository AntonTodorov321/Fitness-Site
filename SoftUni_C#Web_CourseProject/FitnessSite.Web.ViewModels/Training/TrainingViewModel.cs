namespace FitnessSite.Web.ViewModels.Training
{
    using FitnessSite.Web.ViewModels.Exercise;

    public class TrainingViewModel
    {
        public TrainingViewModel()
        {
            Exercises = new HashSet<AllExerciseViewModel>();
        }

        public string Id { get; set; } = null!;

        public bool IsStarted { get; set; }

        public bool IsEnded { get; set; }

        public ICollection<AllExerciseViewModel> Exercises { get; set; }
    }
}
