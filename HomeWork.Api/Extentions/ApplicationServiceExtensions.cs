using HomeWork.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Api.Extentions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureRepositories(services);

            ConfigureServices(services);

            ConfigureDatabase(services, configuration);

            return services;
        }

        private static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HomeWorkDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgresqlDbConnection"));
            });
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {

        }

        private static void ConfigureServices(IServiceCollection services)
        {

        }
    }
}
