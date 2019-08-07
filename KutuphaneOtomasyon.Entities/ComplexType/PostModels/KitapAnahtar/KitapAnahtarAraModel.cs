using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapAnahtar
{
    public class KitapAnahtarAraModel : FilterModel<BaseType.KitapAnahtar>
    {
        public string KitapAdi { get; set; }

        public string Anahtar { get; set; }

        public int KitapId { get; set; }

        private IQueryable<BaseType.KitapAnahtar> KitapIdQuery(IQueryable<BaseType.KitapAnahtar> queryable)
        {
            if (KitapId!=0)
                return queryable.Where(s => s.Kitap.Id==KitapId);
            return queryable;
        }

        private IQueryable<BaseType.KitapAnahtar> AnahtarQuery(IQueryable<BaseType.KitapAnahtar> queryable)
        {
            if (!string.IsNullOrEmpty(Anahtar))
                return queryable.Where(s => s.Anahtar.Trim().ToLower().Contains(Anahtar.ToLower().Trim()));
            return queryable;
        }

        private IQueryable<BaseType.KitapAnahtar> KitapAdiQuery(IQueryable<BaseType.KitapAnahtar> queryable)
        {
            if (!string.IsNullOrEmpty(KitapAdi))
                return queryable.Where(s => s.Kitap.Adi.Trim().ToLower().Contains(KitapAdi.ToLower().Trim()));
            return queryable;
        }

        public override IQueryable<BaseType.KitapAnahtar> ExecuteQueryables(IQueryable<BaseType.KitapAnahtar> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        protected override IQueryable<BaseType.KitapAnahtar> WithoutPageExecuteQueryable(IQueryable<BaseType.KitapAnahtar> queryable)
        {
            queryable = KitapAdiQuery(queryable);
            queryable = KitapIdQuery(queryable);
            queryable = AnahtarQuery(queryable);
            return queryable;
        }
    }
}