using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Abstract;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class BolumManager : IBolumService
    {
        private IBolumDal _bolumDal;
        private IMapper _mapper;
        private IQueryableRepositoryBase<Bolum> _queryable;

        public BolumManager(IBolumDal bolumDal, IMapper mapper, IQueryableRepositoryBase<Bolum> queryable)
        {
            _bolumDal = bolumDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumEkle(BolumEkleModel model)
        {
            var response = _bolumDal.SetState(_mapper.Map<Bolum>(model), EntityState.Added);
            if (response)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.BolumAdi + " Eklendi.",
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.BolumAdi + " Eklenmedi.",
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse BolumleriGetir(BolumAraModel model = null)
        {
            var bolumler = model != null ? model.ExecuteQueryables(_queryable.Table).ToList() : _bolumDal.GetList().ToList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Bölümler Listelendi!!!",
                Data = _mapper.Map<List<BolumSeciciModel>>(bolumler)
            };
        }

        public DataResponse BolumleriGetirTablo(BolumAraModel model = null)
        {
            var bolumler = model != null
                ? model.ExecuteQueryables(_queryable.Table).Include(s=>s.Fakulte).ToList()
                : _queryable.Table.Include(s=>s.Fakulte).ToList();

            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Bölümler Listelendi!!!",
                Data = _mapper.Map<List<BolumTabloModel>>(bolumler)
            };
        }
    }
}