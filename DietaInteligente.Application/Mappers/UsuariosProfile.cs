
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;
using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Application.Mappers;

public class UsuariosProfile : Profile
{
    public UsuariosProfile()
    {
        CreateMap<Usuario, UsuarioViewModel>()
            .ForMember(dest => dest.Objetivo, opt => opt.MapFrom(src => src.Objetivos));

        CreateMap<UsuarioInputModel, Usuario>()
            .ForMember(dest => dest.Objetivos, opt => opt.MapFrom(src => (Objetivos)src.Objetivo.Value));
    }
}
