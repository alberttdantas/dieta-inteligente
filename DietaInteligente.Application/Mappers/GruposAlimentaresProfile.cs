
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class GruposAlimentaresProfile : Profile
{
    public GruposAlimentaresProfile()
    {
        CreateMap<GrupoAlimentar, GrupoAlimentarViewModel>();

        CreateMap<GrupoAlimentarInputModel, GrupoAlimentar>();
    }
}
