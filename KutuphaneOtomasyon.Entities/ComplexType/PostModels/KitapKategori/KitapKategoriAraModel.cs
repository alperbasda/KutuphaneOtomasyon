﻿using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori
{
    public class KitapKategoriAraModel : FilterModel<BaseType.KitapKategori>
    {
        public string KitapKategoriAdi { get; set; }

        private IQueryable<BaseType.KitapKategori> KitapKategoriAdiQuery(IQueryable<BaseType.KitapKategori> queryable)
        {
            if (!string.IsNullOrEmpty(KitapKategoriAdi))
                return queryable.Where(s => s.Adi.ToLower().Trim().Contains(KitapKategoriAdi.ToLower().Trim()));
            return queryable;
        }

        public override IQueryable<BaseType.KitapKategori> ExecuteQueryables(IQueryable<BaseType.KitapKategori> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }


        protected override IQueryable<BaseType.KitapKategori> WithoutPageExecuteQueryable(IQueryable<BaseType.KitapKategori> queryable)
        {
            queryable = KitapKategoriAdiQuery(queryable);
            return queryable;
        }
    }
}