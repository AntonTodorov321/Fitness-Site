namespace FitnessSite.Web
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    using Data;
    using FitnessSite.Data.Models;
    using Infastructure.Extensions;
    using Services.Intarfaces;
    using static Common.GeneralApplicationConstants;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<FitnessSiteDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount =
                    builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

                    options.Password.RequireLowercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

                    options.Password.RequireUppercase =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");

                    options.Password.RequireNonAlphanumeric =
                    builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

                    options.Password.RequiredLength =
                    builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<FitnessSiteDbContext>();


            builder.Services.AddApplicationServices(typeof(IExerciseService));

            builder.Services.ConfigureApplicationCookie(cfg =>
            {
                cfg.LoginPath = "/User/Login";
            });

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error/500");
                app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.SeedTrainer(DevelopmentTrainerIvanEmail);
                app.SeedTrainer(DevelopmentTrainerMariaEmail);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.MapDefaultControllerRoute();
            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}