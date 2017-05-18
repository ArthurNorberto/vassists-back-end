using Ninject.Extensions.Conventions;
using Ninject.Modules;
using VAssists.AppService.Seguranca;
using VAssistsInfra.Seguranca.repositorios;

namespace VAssists.AppService.Ninject
{
    public class AplicacaoResolver : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x => x.FromAssemblyContaining<SegurancaAppServico>().SelectAllClasses().BindDefaultInterface());
            Kernel.Bind(x => x.FromAssemblyContaining<SegurancaRepositorio>().SelectAllClasses().BindDefaultInterface());
        }
    }
}