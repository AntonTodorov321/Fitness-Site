namespace FitnessSite.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Intarfaces;
    using Web.Data;
    using Web.ViewModels.Trainer;
    using Data.Models;

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
                    Id = t.Id.ToString(),
                    ImageUrl = t.ImageUrl,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    Year = t.Year,
                })
                .ToListAsync();

            return allTrainers;
        }

        public async Task<string> GetFullNameTrainerById(string id)
        {
            Trainer trainer =
                await dbContext.Trainers.FirstAsync(t => t.Id.ToString() == id);

            return $"{trainer.FirstName} {trainer.LastName}";
        }

        public async Task<DetailsTrainerViewModel> GetTrainerDetailsAsync(string id)
        {
            DetailsTrainerViewModel trainer = await dbContext
                .Trainers.Select(t => new DetailsTrainerViewModel()
                {
                    Id = t.Id.ToString(),
                    Description = t.Description,
                    ImageUrl = t.ImageUrl,
                    PricePerMonth = t.PricePerMonth,
                    StartedAt = t.StartedAt,
                    TelefoneNumber = t.TelefoneNumber,
                    Year = t.Year
                })
                .FirstAsync(t => t.Id == id);

            trainer.YearExperience = trainer.Year - trainer.StartedAt;
            return trainer;
        }

        public async Task<bool> IsTrainerExesitAsync(string id)
        {
            return await dbContext.Trainers.AnyAsync(t => t.Id.ToString() == id);
        }

        public async Task<bool> IsUserHaveTrainerAsync(string id)
        {
            ApplicationUser? user =
                await dbContext.Users.FirstOrDefaultAsync(u => u.Id.ToString() == id);

            if (user == null)
            {
                return false;
            }

            return user.TrainerId.HasValue;
        }
    }
}
