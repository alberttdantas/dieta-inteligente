﻿
using AutoMapper;
using DietaInteligente.Application.InputModels;
using DietaInteligente.Application.ViewModels;
using DietaInteligente.Domain.Entities;

namespace DietaInteligente.Application.Mappers;

public class UsuariosProfile : Profile
{
    public UsuariosProfile()
    {
        CreateMap<Usuario, UsuarioViewModel>();

        CreateMap<UsuarioInputModel, Usuario>();
    }
}
