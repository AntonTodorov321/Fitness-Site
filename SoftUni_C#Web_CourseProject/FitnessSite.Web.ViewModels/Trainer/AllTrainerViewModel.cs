namespace FitnessSite.Web.ViewModels.Trainer
{
    public class AllTrainerViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int Year { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
