using AutoMapper;
using DietaInteligente.Domain.Enums;

namespace DietaInteligente.Application.Results;

public class ObjetivoValueConverter : IValueConverter<int?, Objetivos>
{
    public Objetivos Convert(int? sourceMember, ResolutionContext context)
    {
        return sourceMember.HasValue ? (Objetivos)sourceMember.Value : default;
    }
}
