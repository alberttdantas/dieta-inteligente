
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class DietasProfile : Profile
{
    public DietasProfile()
    {
        CreateMap<Dieta, DietaViewModel>();

        CreateMap<DietaInputModel, Dieta>();
    }
}