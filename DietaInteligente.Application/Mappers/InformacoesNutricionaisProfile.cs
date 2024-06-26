﻿
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class InformacoesNutricionaisProfile : Profile
{
    public InformacoesNutricionaisProfile()
    {
        CreateMap<InformacaoNutricional, InformacaoNutricionalViewModel>();

        CreateMap<InformacaoNutricionalInputModel, InformacaoNutricional>();
    }
}
