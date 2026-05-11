using MultiTenantSolution.Data;
using Microsoft.EntityFrameworkCore;
using MultiTenantSolution;
using MultiTenantSolution.Provider;
using MultiTenantSolution.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<TenantData>();

builder.Services.AddDbContext<AppDbContext>(p =>
    p.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultiTenantDb;Integrated Security=True")
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "MultiTenantSolution v1"));
}

app.UseMiddleware<TenantMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
