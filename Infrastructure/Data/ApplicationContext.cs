using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure.Data;
public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Departamento> Departamentos { get; set; }
}