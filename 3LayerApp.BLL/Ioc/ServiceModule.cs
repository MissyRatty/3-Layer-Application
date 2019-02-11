using _3LayerApp.DAL.Interfaces;
using _3LayerApp.DAL.Repositories;
using Ninject.Modules;

namespace _3LayerApp.BLL.Ioc
{
    public class ServiceModule : NinjectModule
    {
        private string _connectionString;
        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope().WithConstructorArgument(_connectionString);
        }
    }
}
