namespace FitnessSite.Web.ViewModels.Training
{
    using FitnessSite.Web.ViewModels.Exercise;

    public class TrainingViewModel
    {
        public TrainingViewModel()
        {
            Exercises = new HashSet<AllExerciseViewModel>();
        }

        public ICollection<AllExerciseViewModel> Exercises { get; set; }
    }
}
