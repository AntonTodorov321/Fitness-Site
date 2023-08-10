namespace FitnessSite.Web.ViewModels.Message
{
    public class ShowDetailsMessageViewModel
    {
        public string Id { get; set; } = null!;

        public string? Description { get; set; }

        public string? Questions { get; set; }

        public string SenderId { get; set; } = null!;
    }
}
