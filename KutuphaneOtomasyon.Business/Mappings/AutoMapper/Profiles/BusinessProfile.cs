using AutoMapper;
using KutuphaneOtomasyon.Entities.BaseType;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Bolum;
using KutuphaneOtomasyon.Entities.ComplexType.PostModels.Fakulte;

namespace KutuphaneOtomasyon.Business.Mappings.AutoMapper.Profiles
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<FakulteEkleModel, Fakulte>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.FakulteAdi));
            CreateMap<BolumEkleModel, Bolum>()
                .ForMember(d => d.Adi, t => t.MapFrom(v => v.BolumAdi))
                .ForMember(d => d.FakulteId, t => t.MapFrom(v => v.FakulteId));
        }
    }
}