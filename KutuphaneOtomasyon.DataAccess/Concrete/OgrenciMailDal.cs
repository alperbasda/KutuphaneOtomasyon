using KutuphaneOtomasyon.Core.DataAccess.Concrete;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Core.EntityFramework;
using KutuphaneOtomasyon.Entities.BaseType;

namespace KutuphaneOtomasyon.DataAccess.Concrete
{
    public class OgrenciMailDal : RepositoryBase<OgrenciMail, KutuphaneContext>,IOgrenciMailDal
    {
        
    }
}