
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class RestricoesDieteticasProfile : Profile
{
    public RestricoesDieteticasProfile()
    {
        CreateMap<RestricoesDieteticas, RestricaoDieteticaViewModel>();

        CreateMap<RestricaoDieteticaInputModel, RestricoesDieteticas>();
    }
}
