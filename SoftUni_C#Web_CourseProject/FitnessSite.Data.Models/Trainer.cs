namespace FitnessSite.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Common.EntityValidationsConstants.Trainer;

    public class Trainer
    {
        public Trainer()
        {
            ApllicationUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLengh)]
        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public int StartedAt { get; set; }

        public decimal PricePerMonth { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLengh)]
        public string Description { get; set; } = null!;

        public int YearExperience
        {
            get
            {
                return this.Year - this.YearExperience;
            }
        }
        public virtual ICollection<ApplicationUser> ApllicationUsers { get; set; }
    }
}
