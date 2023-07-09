namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.TypeExercise;

    public interface IExerciseService
    {
        public Task<IEnumerable<TypeExerciseViewModel>> AllExerciseAsync();
    }
}
