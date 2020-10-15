using CRUD.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Service.DependencyInjection
{
    public class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<AppDataContext>(
                        options =>
                        options.UseMySql(configuration.GetConnectionString("ConnectionString"))
                );
        }
    }
}
