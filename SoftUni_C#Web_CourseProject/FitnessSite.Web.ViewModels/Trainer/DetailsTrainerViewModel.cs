namespace FitnessSite.Web.ViewModels.Trainer
{
    public class DetailsTrainerViewModel
    {
        public string Id { get; set; } = null!;
        public int StartedAt { get; set; }
        public decimal PricePerMonth { get; set; }
        public string TelefoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int YearExperience { get; set; }
        public int Year { get; set; }
    }
}
