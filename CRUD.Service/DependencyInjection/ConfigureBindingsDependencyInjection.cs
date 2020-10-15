using CRUD.Service.DependencyInjection.RepositoryInjection.ApplicationServiceInjection;
using CRUD.Service.DependencyInjection.RepositoryInjection.RepositoryInjection;
using CRUD.Service.DependencyInjection.RepositoryInjection.UnitOfWorkInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD.Service.DependencyInjection
{
    public class ConfigureBindingsDependencyInjection
    {
        public static void RegisterBindings(IServiceCollection services, IConfiguration configuration)
        {
            ConfigureBindingsDatabaseContext.RegisterBindings(services, configuration);

            #region ApplicationService
            ConfigureBindingsApplicationService.RegisterBindings(services, configuration);
            #endregion

            #region Repository
            ConfigureBindingsRepository.RegisterBindings(services, configuration);
            #endregion

            #region UnitOfWork
            ConfigureBindingsUnitOfWork.RegisterBindings(services, configuration);
            #endregion
        }
    }
}
