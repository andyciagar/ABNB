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
        var connectionString = services.BuildServiceProvider().GetRequiredService<IConfiguration>().GetConnectionString("abnbdb");
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(connectionString)
        );
        services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
    }
}
