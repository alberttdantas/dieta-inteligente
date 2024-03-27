namespace DietaInteligente.Domain.Entities;

public class Usuarios
{
    public Usuarios(string nome, string email, decimal peso, string objetivo, decimal altura)
    {
        Nome = nome;
        Email = email;
        Peso = peso;
        Altura = altura;
        Objetivo = objetivo;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public decimal Peso { get; set; }
    public decimal Altura { get; set; }
    public string Objetivo { get; set; }
    public ICollection<Dieta> Dietas { get; set; }
    public ICollection<RestricoesDieteticas> RestricoesDieteticas { get; set; }
}