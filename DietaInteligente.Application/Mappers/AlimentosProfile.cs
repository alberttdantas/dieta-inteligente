using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class AlimentosProfile : Profile
{
    public AlimentosProfile()
    {
        CreateMap<Alimento, AlimentoViewModel>();

        CreateMap<AlimentoInputModel, Alimento>();
    }
}