namespace FitnessSite.Data.Configutarion
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(GenerateUsers());
        }

        private ApplicationUser[] GenerateUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = Guid.Parse("673FC005-4FBB-403B-8931-61C02F901F56"),
                    Email = "ivantrainer@gmail.com",
                    NormalizedEmail = "IVANTRAINER@GMAIL.COM",
                    UserName = "ivantrainer@gmail.com",
                    NormalizedUserName = "IVANTRAINER@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEPkFrXPoUKAiePrdfD7MpV8GM3DDLiGHeL0t59CRhINfNeFNYk5KsFBtvu4333byRQ==",
                    SecurityStamp = "BNB3HKKNVR6EQGG33PZ2PKZZ2E3A3BRM",
                    ConcurrencyStamp = "e58d020a-8b2e-4638-ab42-d61fc242ed18",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                },
                new ApplicationUser()
                {
                    Id = Guid.Parse("3CB73CF9-DE66-4109-AA37-B36B72787DF7"),
                    Email = "mariatrainer@gmail.com",
                    NormalizedEmail = "MARIATRAINER@GMAIL.COM",
                    UserName = "mariatrainer@gmail.com",
                    NormalizedUserName = "MARIATRAINER@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAED2g4IMnJy5+pVB/Al2nlBK2s6EfebghA0LGqA+e1qJ45j9COBwKW9gIxV6jhrmKvw==",
                    SecurityStamp = "3RCFHYMOTYHUGUNQDYGDXXG5OWPTH5J4",
                    ConcurrencyStamp = "cc188f75-7cf1-43eb-9b59-45b85f0db93b",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                }
            };

            return users.ToArray();
        }
    }
}
