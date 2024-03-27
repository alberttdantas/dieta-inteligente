
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class GruposAlimentaresProfile : Profile
{
    public GruposAlimentaresProfile()
    {
        CreateMap<GruposAlimentares, GrupoAlimentarViewModel>();

        CreateMap<GrupoAlimentarInputModel, GruposAlimentares>();
    }
}
