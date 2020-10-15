using CRUD.Service.ApplicationServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Service.DependencyInjection.RepositoryInjection.ApplicationServiceInjection
{
    public class ConfigureBindingsApplicationService
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CategoriaApplicationServices>();
            services.AddScoped<ProdutoApplicationServices>();
        }
    }
}
