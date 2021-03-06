﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KutuphaneOtomasyon.Core.Entity.Concrete;
using KutuphaneOtomasyon.Entities.Enum;

namespace KutuphaneOtomasyon.Entities.ComplexType.PostModels.Kitap
{
    public class KitapAraModel : FilterModel<BaseType.Kitap>
    {
        public string KitapAdi { get; set; }

        public string ISBN { get; set; }

        public string Kod { get; set; }

        public string Yazar { get; set; }

        public int KategoriId { get; set; }

        public int YayinYili { get; set; }

        public KitapDurum KitapDurum { get; set; }

        public IQueryable<BaseType.Kitap> KitapAdiQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (!string.IsNullOrEmpty(KitapAdi))
                return queryable.Where(s => s.Adi.ToLower().Trim().Contains(KitapAdi.ToLower().Trim()) || s.KitapAnahtarlari.Any(w=>w.Anahtar.Trim().ToLower().Contains(KitapAdi.Trim())));
            return queryable;
        }

        public IQueryable<BaseType.Kitap> ISBNQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (!string.IsNullOrEmpty(ISBN))
                return queryable.Where(s => s.ISBN.Trim() == ISBN.Trim());
            return queryable;
        }


        public IQueryable<BaseType.Kitap> KodQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (!string.IsNullOrEmpty(Kod))
                return queryable.Where(s => s.Kod.Trim() == Kod.Trim());
            return queryable;
        }

        public IQueryable<BaseType.Kitap> YazarQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (!string.IsNullOrEmpty(Yazar))
                return queryable.Where(s => s.Yazar.Trim() == Yazar.Trim());
            return queryable;
        }

        public IQueryable<BaseType.Kitap> KategoriIdQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (KategoriId!=0)
                return queryable.Where(s => s.KitapKategoriId == KategoriId);
            return queryable;
        }

        public IQueryable<BaseType.Kitap> YayinYiliQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (YayinYili != 0)
                return queryable.Where(s => s.YayinYili == YayinYili);
            return queryable;
        }

        public IQueryable<BaseType.Kitap> KitapDurumQuery(IQueryable<BaseType.Kitap> queryable)
        {
            if (KitapDurum != KitapDurum.SecimYapilmadi)
                return queryable.Where(s => s.KitapDurum == KitapDurum);
            return queryable;
        }

        public override IQueryable<BaseType.Kitap> ExecuteQueryables(IQueryable<BaseType.Kitap> queryable)
        {
            queryable = WithoutPageExecuteQueryable(queryable);
            queryable = PageQueryable(queryable);
            return queryable;
        }

        protected override IQueryable<BaseType.Kitap> WithoutPageExecuteQueryable(IQueryable<BaseType.Kitap> queryable)
        {
            queryable = KitapAdiQuery(queryable);
            queryable = ISBNQuery(queryable);
            queryable = KodQuery(queryable);
            queryable = YazarQuery(queryable);
            queryable = KategoriIdQuery(queryable);
            queryable = YayinYiliQuery(queryable);
            queryable = KitapDurumQuery(queryable);
            return queryable;
        }
    }
}