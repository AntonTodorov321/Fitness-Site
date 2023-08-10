namespace FitnessSite.Web.ViewModels.Message
{
    public class AllMessageViewModel
    {
        public string Id { get; set; } = null!;

        public string SenderFirstName { get; set; } = null!;

        public string SenderLastName { get; set; } = null!;

        public string? Description { get; set; }
    }
}
