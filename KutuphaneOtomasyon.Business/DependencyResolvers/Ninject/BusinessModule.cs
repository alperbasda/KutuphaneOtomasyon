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
            Bind<IKitapKategoriService>().To<KitapKategoriManager>();
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

            Bind<IBolumDal>().To<BolumDal>().InSingletonScope();
            Bind<IFakulteDal>().To<FakulteDal>().InSingletonScope();
            Bind<IKitapKategoriDal>().To<KitapKategoriDal>();
            Bind<IKitapAnahtarDal>().To<KitapAnahtarDal>().InSingletonScope();
            Bind<IKitapHareketDal>().To<KitapHareketDal>().InSingletonScope();
            Bind<IKitapDal>().To<KitapDal>().InSingletonScope();
            Bind<IKullaniciDal>().To<KullaniciDal>().InSingletonScope();
            Bind<IOgrenciAdresDal>().To<OgrenciAdresDal>().InSingletonScope();
            Bind<IOgrenciMailDal>().To<OgrenciMailDal>().InSingletonScope();
            Bind<IOgrenciDal>().To<OgrenciDal>().InSingletonScope();
            Bind<IOgrenciTelefonDal>().To<OgrenciTelefonDal>().InSingletonScope();
            Bind<IViewDal>().To<ViewDal>().InSingletonScope();

            #endregion

            #region DatabaseBindings
            Bind<DbContext>().To<KutuphaneContext>();
            Bind(typeof(IQueryableRepositoryBase<>)).To(typeof(QueryableRepositoryBase<>));
            #endregion
        }
    }
}