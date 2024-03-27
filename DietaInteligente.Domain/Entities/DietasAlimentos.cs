namespace DietaInteligente.Domain.Entities;

public class DietaAlimento
{

    public DietaAlimento(int dietaId, int alimentoId, decimal quantidadeGramas)
    {
        DietaId = dietaId;
        AlimentoId = alimentoId;
        QuantidadeGramas = quantidadeGramas;
    }

    public DietaAlimento(int dietaId, int alimentoId)
    {
        DietaId = dietaId;
        AlimentoId = alimentoId;
    }

    public int DietaId { get; set; }
    public Dieta Dietas { get; set; }
    public int AlimentoId { get; set; }
    public Alimento Alimentos { get; set; }
    public decimal QuantidadeGramas { get; set; }
}