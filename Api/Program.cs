using Infrastructure;
using Application.Departamentos.Queries;
using Infrastructure.Data;
using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();
builder.Services.AddScoped<IDepartamentoGetById, DepartamentoGetById>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    await dbContext.Database.EnsureCreatedAsync();

    if (app.Environment.IsDevelopment() && !dbContext.Departamentos.Any())
    {
        dbContext.Departamentos.AddRange(
            new Departamento
            {
                Nombre = "Departamento 1",
            },
            new Departamento
            {
                Nombre = "Departamento 2",
            }
        );

        await dbContext.SaveChangesAsync();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet(
        "/departamentos/{id}",
        async (int id, IDepartamentoGetById departamentoGetById) =>
        {
            var departamento = await departamentoGetById.Execute(id);

            if (departamento is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(departamento);
        }
    )
    .WithName("GetDepartamentoById");

app.MapGet(
        "/departamentos", 
        async (IDepartamentoGetAll departamentoGetAll) =>
        {
            var departamentos = await departamentoGetAll.Execute();
            return Results.Ok(departamentos);
        }
    )
    .WithName("GetDepartamentos");

app.UseHttpsRedirection();

app.Run();

