using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using KutuphaneOtomasyon.Business.Abstract;
using KutuphaneOtomasyon.Business.Aspects.AuthorizationAspects;
using KutuphaneOtomasyon.Business.Aspects.ExceptionAspects;
using KutuphaneOtomasyon.Business.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using KutuphaneOtomasyon.Core.DataAccess.Abstract;
using KutuphaneOtomasyon.DataAccess.Concrete;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.GetModels.Fakulte;
using KutuphaneOtomasyon.Entities.ComplexType.PageModels;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;
using KutuphaneOtomasyon.Entities.Response.Concrete;

namespace KutuphaneOtomasyon.Business.Concrete
{
    public class FakulteManager : IFakulteService
    {
        private FakulteDal _fakulteDal;
        private IQueryableRepositoryBase<Fakulte> _queryable;
        private IMapper _mapper;

        public FakulteManager(FakulteDal fakulteDal, IMapper mapper, IQueryableRepositoryBase<Fakulte> queryable)
        {
            _fakulteDal = fakulteDal;
            _mapper = mapper;
            _queryable = queryable;
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteEkle(FakulteEkleModel model)
        {
            bool sonuc = _fakulteDal.SetState(_mapper.Map<Fakulte>(model), EntityState.Added);
            if (sonuc)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = model.FakulteAdi + " Eklendi"
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = model.FakulteAdi + " Eklenemedi"
            };
        }

        [ExceptionLogAspect(typeof(DatabaseLogger), AspectPriority = 1)]
        [SecuredOperationAspect(Roles = "Kullanici")]
        public DataResponse FakulteleriGetir(FakulteAraModel model = null)
        {
            var fakulteler = model?.ExecuteQueryables(_queryable.Table).ToList() ?? _fakulteDal.GetList();
            return new DataResponse
            {
                Tamamlandi = true,
                Mesaj = "Fakulteler Listelendi !!!",
                Data = _mapper.Map<List<FakulteModel>>(fakulteler)
            };
        }

        public DataResponse FakulteleriGetirTablo(FakulteAraModel model = null)
        {

            var response = FakulteleriGetir(model);
            int toplamData = ToplamDataGetir(model);
            if (response.Tamamlandi)
                return new DataResponse
                {
                    Tamamlandi = true,
                    Mesaj = "Fakulteler Listelendi",
                    Data = new PageModel
                    {
                        CurrentPage = model?.Sayfa ?? 1,
                        TableData = response.Data,
                        TotalPage = ToplamSayfaGetir(toplamData),
                        TotalData = toplamData
                    }
                };
            return new DataResponse
            {
                Tamamlandi = false,
                Mesaj = "Fakulteler Listelenemedi",
                Data = new PageModel
                {
                    CurrentPage = 1,
                    TableData = null,
                    TotalPage = 1,
                    TotalData = 0,
                }
            };
        }


        private int ToplamDataGetir(FakulteAraModel model = null)
        {
            return model?.Count(_queryable.Table) ?? _fakulteDal.Count();
        }
        private int ToplamSayfaGetir(int toplamData)
        {
            return (int)Math.Ceiling((decimal)toplamData / Convert.ToInt32(ConfigurationManager.AppSettings["DataPerPage"]));
        }
    }
}