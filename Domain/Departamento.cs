using System.ComponentModel.DataAnnotations.Schema;
using Domain.Comunes;

namespace Domain;

public class Departamento : Entidad
{
    public Nombre Nombre { get; set; } = new Nombre(string.Empty);
    
    //public Dinero Precio { get; set; } = new Dinero(0, Moneda.USD);
}


public record Nombre(string Value); 

public record Dinero(decimal Value, Moneda Moneda);

public record Moneda 
{
    public static readonly Moneda USD = new Moneda("USD");
    public static readonly Moneda EUR = new Moneda("EUR");
    public string Codigo { get;private init; } 

    public static Moneda FromCodigo(string codigo) => codigo switch
    {
        "EUR" => EUR,
        _ => USD,
    };

    private Moneda(string codigo)
    {
        Codigo = codigo;
    } 
}
public interface IDepartamentoRepository
{
    Task<Departamento?> GetByIdAsync(int id);
    Task<List<Departamento>> GetAllAsync();
    Task AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}