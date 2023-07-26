namespace FitnessSite.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FitnessSite.Data.Models;
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
                    Id = t.Id,
                    ImageUrl = t.ImageUrl,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Year = t.Year,
                })
                .ToListAsync();

            return allTrainers;
        }

        public async Task<DetailsTrainerViewModel> GetTrainerDetailsAsync(string id)
        {
            DetailsTrainerViewModel trainer = await dbContext
                .Trainers.Select(t => new DetailsTrainerViewModel()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Email = t.Email,
                    ImageUrl = t.ImageUrl,
                    PricePerMonth = t.PricePerMonth,
                    StartedAt = t.StartedAt,
                    TelefoneNumber = t.TelefoneNumber,
                    YearExperience = t.YearExperience
                })
                .FirstAsync(t => t.Id.ToString() == id);

            return trainer;
        }
    }
}
