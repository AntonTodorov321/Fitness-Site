namespace FitnessSite.Web.Infastructure.Extensions
{
    using System.Reflection;

    using Microsoft.Extensions.DependencyInjection;

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
    }
}
