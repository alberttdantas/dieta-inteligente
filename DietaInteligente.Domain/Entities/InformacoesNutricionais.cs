namespace DietaInteligente.Domain.Entities;

public class InformacaoNutricional
{
    public InformacaoNutricional(int alimentoId, decimal calorias, decimal proteinas, decimal gorduras, decimal carboidratos, decimal fibras)
    {
        AlimentoId = alimentoId;
        Calorias = calorias;
        Proteinas = proteinas;
        Gorduras = gorduras;
        Carboidratos = carboidratos;
        Fibras = fibras;
    }

    public int AlimentoId { get; set; }
    public Alimento ALimento { get; set; }
    public decimal Calorias { get; set; }
    public decimal Proteinas { get; set; }
    public decimal Gorduras { get; set; }
    public decimal Carboidratos { get; set; }
    public decimal Fibras { get; set; }
}
