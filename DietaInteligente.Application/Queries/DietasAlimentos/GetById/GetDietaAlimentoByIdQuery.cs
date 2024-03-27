﻿
using DietaInteligente.Application.ViewModels;
using MediatR;

namespace DietaInteligente.Application.Queries.DietasAlimentos.GetById;

public class GetDietaAlimentoByIdQuery : IRequest<DietaAlimentoViewModel>
{
    public int DietaId { get; set; }
    public GetDietaAlimentoByIdQuery (int id) { DietaId = id; }
}
