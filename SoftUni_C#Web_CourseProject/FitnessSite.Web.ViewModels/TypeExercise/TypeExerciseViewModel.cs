namespace FitnessSite.Web.ViewModels.TypeExercise
{
    using Exercise;

    public class TypeExerciseViewModel
    {
        public string Name { get; set; } = null!;

        public ICollection<AllExerciseViewModel> AllExercises { get; set; } =
            new HashSet<AllExerciseViewModel>();
    }
}
