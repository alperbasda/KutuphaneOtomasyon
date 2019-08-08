using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class ViewManager : IViewService
    {
        private IViewDal _viewDal;

        public ViewManager(IViewDal viewDal)
        {
            _viewDal = viewDal;
        }

        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse SiteStatistics()
        {
            return new DataResponse{Tamamlandi = true};
        }
    }
}