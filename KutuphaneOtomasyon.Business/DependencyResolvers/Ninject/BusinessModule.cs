using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Concrete;
using Ninject.Modules;

namespace KutuphaneOtomasyon.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IOgrenciService>().To<OgrenciManager>();
        }
    }
}