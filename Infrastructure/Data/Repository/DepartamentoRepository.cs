using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository;

public class DepartamentoRepository : IDepartamentoRepository
{
    private readonly ApplicationContext _context;

    public DepartamentoRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task DeleteAsync(int id)
    {
        var departamento = await _context.Departamentos.FindAsync(id);

        if (departamento is null)
        {
            return;
        }

        _context.Departamentos.Remove(departamento);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Departamento>> GetAllAsync()
    {
        return await _context.Departamentos
            .AsNoTracking()
            .OrderBy(d => d.Id)
            .ToListAsync();
    }

    public async Task<Departamento?> GetByIdAsync(int id)
    {
        return await _context.Departamentos
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public Task AddAsync(Departamento departamento)
    {
        _context.Departamentos.Add(departamento);
        return _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Departamento departamento)
    {
        var existingDepartamento = await _context.Departamentos.FindAsync(departamento.Id);

        if (existingDepartamento is null)
        {
            return;
        }

        existingDepartamento.Nombre = departamento.Nombre;
        await _context.SaveChangesAsync();
    }
}
