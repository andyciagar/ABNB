using Domain;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class InyeccionDependencias
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>((serviceProvider, options) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("abnbdb")
                ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'abnbdb'.");

            options.UseNpgsql(connectionString);
        });

        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
    }
}
