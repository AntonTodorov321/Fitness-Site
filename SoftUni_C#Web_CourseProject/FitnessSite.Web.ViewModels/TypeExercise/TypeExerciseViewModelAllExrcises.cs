namespace FitnessSite.Web.ViewModels.TypeExercise
{
    using Exercise;

    public class TypeExerciseViewModelAllExrcises
    {
        public string Name { get; set; } = null!;

        public ICollection<AllExerciseViewModel> AllExercises { get; set; } =
            new HashSet<AllExerciseViewModel>();
    }
}
