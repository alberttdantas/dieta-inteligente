using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class AlimentosProfile : Profile
{
    public AlimentosProfile()
    {
        CreateMap<Alimento, AlimentoViewModel>()
            .ForMember(dest => dest.InformacoesNutricionais, opt => opt.MapFrom(src => src.InformacaoNutricional));

        CreateMap<AlimentoInputModel, Alimento>();
    }
}