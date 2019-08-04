using System.Data.Entity;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Concrete;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.Core.DataAccess.Concrete;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Concrete;
using KutuphaneOtomasyon.DataAccess.Core.EntityFramework;
using Ninject.Modules;

namespace KutuphaneOtomasyon.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {

            #region ServiceBindings
            Bind<IBolumService>().To<BolumManager>();
            Bind<IFakulteService>().To<FakulteManager>();
            Bind<IKitapAnahtarService>().To<KitapAnahtarManager>();
            Bind<IKitapHareketService>().To<KitapHareketManager>();
            Bind<IKitapService>().To<KitapManager>();
            Bind<IKullaniciService>().To<KullaniciManager>();
            Bind<IOgrenciAdresService>().To<OgrenciAdresManager>();
            Bind<IOgrenciMailService>().To<OgrenciMailManager>();
            Bind<IOgrenciService>().To<OgrenciManager>();
            Bind<IOgrenciTelefonService>().To<OgrenciTelefonManager>();
            Bind<IViewService>().To<ViewManager>();

            #endregion

            #region DataAccessBindings

            Bind<IBolumDal>().To<BolumDal>();
            Bind<IFakulteDal>().To<FakulteDal>();
            Bind<IKitapAnahtarDal>().To<KitapAnahtarDal>();
            Bind<IKitapHareketDal>().To<KitapHareketDal>();
            Bind<IKitapDal>().To<KitapDal>();
            Bind<IKullaniciDal>().To<KullaniciDal>();
            Bind<IOgrenciAdresDal>().To<OgrenciAdresDal>();
            Bind<IOgrenciMailDal>().To<OgrenciMailDal>();
            Bind<IOgrenciDal>().To<OgrenciDal>();
            Bind<IOgrenciTelefonDal>().To<OgrenciTelefonDal>();
            Bind<IViewDal>().To<ViewDal>();

            #endregion

            #region DatabaseBindings
            Bind<DbContext>().To<KutuphaneContext>();
            Bind(typeof(IQueryableRepositoryBase<>)).To(typeof(QueryableRepositoryBase<>));
            #endregion
        }
    }
}