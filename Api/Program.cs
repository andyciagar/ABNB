using Infrastructure.Data.Repository;
using Domain;
using Application.Departamentos.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IDepartamentoGetAll, DepartamentoGetAll>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

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

