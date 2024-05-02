
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using System.Linq;

namespace DietaInteligente.Application.Mappers;

public class DietasAlimentosProfile : Profile
{
    public DietasAlimentosProfile()
    {
        CreateMap<DietaAlimento, DietaAlimentoViewModel>()
            .ForMember(dest => dest.Alimento, opt => opt.MapFrom(src => new AlimentoViewModel
            {
                Id = src.Alimentos.Id,
                Nome = src.Alimentos.Nome,
                GrupoAlimentarId = src.Alimentos.GrupoAlimentarId
            }))
            .ForMember(dest => dest.QuantidadeGramas, opt => opt.MapFrom(src => src.QuantidadeGramas));

        CreateMap<DietaAlimentoInputModel, DietaAlimento>();
    }
}
