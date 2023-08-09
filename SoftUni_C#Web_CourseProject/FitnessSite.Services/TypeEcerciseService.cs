namespace FitnessSite.Services
{
    using System;
    using System.Collections.Generic;

    using Web.Data;
    using Intarfaces;
    using Web.ViewModels.TypeExercise;

    public class TypeEcerciseService : ITypeExerciseService
    {
        private readonly FitnessSiteDbContext dbContext;

        public TypeEcerciseService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<TypeExerciseViewModel> GetTypesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
