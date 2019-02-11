using _3LayerApp.BLL.Interfaces;
using _3LayerApp.BLL.Services;
using Ninject.Modules;

namespace _3LayerApp.Web.Utils
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAccountService>().To<AccountService>();
            Bind<ITransactionTypeService>().To<TransactionTypeService>();
            Bind<ITransactionService>().To<TransactionService>();
        }
    }
}