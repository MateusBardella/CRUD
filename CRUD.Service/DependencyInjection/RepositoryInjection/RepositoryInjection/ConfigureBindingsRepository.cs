using CRUD.Infrastructure.Persistance.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Service.DependencyInjection.RepositoryInjection.RepositoryInjection
{
    public class ConfigureBindingsRepository
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<ProdutoRepository>();
        }
    }
}
