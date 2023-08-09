namespace FitnessSite.Services.Intarfaces
{
    using Web.ViewModels.TypeExercise;

    public interface ITypeExerciseService
    {
        public Task<ICollection<TypeExerciseViewModel>> GetTypesAsync();

        public Task<bool> IsTypeExistAsync(int id);
    }
}
