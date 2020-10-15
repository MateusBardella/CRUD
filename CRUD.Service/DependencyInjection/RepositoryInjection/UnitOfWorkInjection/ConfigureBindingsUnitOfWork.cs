using CRUD.Infrastructure.Persistance.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.Service.DependencyInjection.RepositoryInjection.UnitOfWorkInjection
{
    public class ConfigureBindingsUnitOfWork
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ProdutosUnitOfWork>();
        }
    }
}
