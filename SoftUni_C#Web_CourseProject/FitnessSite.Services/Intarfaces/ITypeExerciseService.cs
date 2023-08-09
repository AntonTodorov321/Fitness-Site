namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.TypeExercise;

    public interface ITypeExerciseService
    {
        public ICollection<TypeExerciseViewModel> GetTypesAsync();
    }
}
