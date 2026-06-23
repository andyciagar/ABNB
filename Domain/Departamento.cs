namespace Domain;

public class Departamento
{
    Public int Id { get; set; }
    Public string Nombre { get; set; } = string.Empty;
}

public interface IDepartamentoRepository
{
    Task<Departamento?> GetByIdAsync(int id);
    Task<List<Departamento>> GetAllAsync();
    Task AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}