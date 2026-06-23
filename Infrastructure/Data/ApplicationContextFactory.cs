using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__abnbdb")
            ?? "Host=localhost;Port=5432;Database=abnbdb;Username=postgres;Password=postgres";

        optionsBuilder.UseNpgsql(connectionString);

        return new ApplicationContext(optionsBuilder.Options);
    }
}