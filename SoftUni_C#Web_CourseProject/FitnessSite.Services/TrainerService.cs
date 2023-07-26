namespace FitnessSite.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Intarfaces;
    using Microsoft.EntityFrameworkCore;
    using Web.Data;
    using Web.ViewModels.Trainer;

    public class TrainerService : ITrainerService
    {
        private readonly FitnessSiteDbContext dbContext;

        public TrainerService(FitnessSiteDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<AllTrainerViewModel>> GetAllTrainersAsync()
        {
            List<AllTrainerViewModel> allTrainers = await dbContext.Trainers
                .Select(t => new AllTrainerViewModel()
                {
                    ImageUrl = t.ImageUrl,
                    Name = t.FirstName,
                    Year = t.Year,
                })
                .ToListAsync();

            return allTrainers;
        }
    }
}
