using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.KitapKategori;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.KitapKategori;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class KitapKategoriManager:IKitapKategoriService
    {
        private IKitapKategoriDal _kitapKategoriDal;
        private IQueryableRepositoryBase<KitapKategori> _queryable;
        private IMapper _mapper;

        public KitapKategoriManager(IKitapKategoriDal kitapKategoriDal, IMapper mapper, IQueryableRepositoryBase<KitapKategori> queryable)
        {
            _kitapKategoriDal = kitapKategoriDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapKategoriEkle(KitapKategoriEkleModel model)
        {
            var response = _kitapKategoriDal.SetState(_mapper.Map<KitapKategori>(model), EntityState.Added);
            if(response)
                return  new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.KitapKategoriAdi+" Eklendi."
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.KitapKategoriAdi+" Eklenemedi."
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapKategoriGetir(KitapKategoriAraModel model = null)
        {
            var response = model?.ExecuteQueryables(_queryable.Table).ToList() ?? _kitapKategoriDal.GetList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitap Kategorileri Listelendi!!!",
                Data = _mapper.Map<List<KitapKategoriModel>>(response)
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse KitapKategoriGetirTablo(KitapKategoriAraModel model)
        {
            var response = model.ExecuteQueryables(_queryable.Table).ToList();
            var dataSayisi = model.Count(_queryable.Table);
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Kitap Kategorileri Listelendi!!!",
                Data = new PageModel
                {
                    SuankiSayfa = model.Sayfa,
                    TabloData = _mapper.Map<List<KitapKategoriModel>>(response),
                    ToplamData = dataSayisi,
                    ToplamSayfa = model.PageCount(dataSayisi)
                }
            };
        }
    }
}