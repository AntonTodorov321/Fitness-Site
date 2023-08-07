namespace FitnessSite.Web.Infastructure.Extensions
{
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using FitnessSite.Data.Models;
    using static Common.GeneralApplicationConstants;

    public static class WebApplicationBuilderExtensions
    {
        public static void AddApplicationServices(this IServiceCollection service, Type serviceType)
        {
            Assembly? assembly = Assembly.GetAssembly(serviceType);

            if (assembly == null)
            {
                throw new InvalidOperationException("Invalid Service type!");
            }

            Type[] implemationTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();

            foreach (var currentType in implemationTypes)
            {
                Type? interfaceType = currentType.GetInterface($"I{currentType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No interface with {currentType.Name} name");
                }

                service.AddScoped(interfaceType, currentType);
            }

        }

        public static IApplicationBuilder SeedTrainer(this IApplicationBuilder app, string email)
        {
            using IServiceScope scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;

            UserManager<ApplicationUser> userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            RoleManager<IdentityRole<Guid>> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            Task.Run(async() =>
            {
                ApplicationUser user = await userManager.FindByEmailAsync(email);
                bool isUserInRole = await userManager.IsInRoleAsync(user, TrainerRoleName);

                if (await roleManager.RoleExistsAsync(TrainerRoleName) && isUserInRole)
                {
                    return;
                }

                IdentityRole<Guid> role = new IdentityRole<Guid>(TrainerRoleName);

                await roleManager.CreateAsync(role);

                await userManager.AddToRoleAsync(user, TrainerRoleName);
            })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
