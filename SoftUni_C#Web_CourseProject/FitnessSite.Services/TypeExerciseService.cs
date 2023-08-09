namespace FitnessSite.Services
{
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Web.Data;
    using Intarfaces;
    using Web.ViewModels.TypeExercise;

    public class TypeExerciseService : ITypeExerciseService
    {
        private readonly FitnessSiteDbContext dbContext;

        public TypeExerciseService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ICollection<TypeExerciseViewModel>> GetTypesAsync()
        {
            ICollection<TypeExerciseViewModel> allTypes =
                await dbContext.TypeExercises.Select(te => new TypeExerciseViewModel()
                {
                    Id = te.Id,
                    Name = te.Name,
                })
                .ToArrayAsync();

            return allTypes;
        }

        public async Task<bool> IsTypeExistAsync(int id)
        {
            return await dbContext.TypeExercises.AnyAsync(te => te.Id == id);
        }
    }
}
