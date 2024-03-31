﻿using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Domain.Entities;

public class Usuario
{
    public Usuario(string nome, string email, decimal peso, decimal altura, Objetivos objetivos)
    {
        Nome = nome;
        Email = email;
        Peso = peso;
        Altura = altura;
        Objetivos = objetivos;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public Objetivos Objetivos { get; set; }
    public ICollection<Dieta> Dietas { get; set; }
    public ICollection<RestricaoDietetica> RestricoesDieteticas { get; set; }
}