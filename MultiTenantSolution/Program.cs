using MultiTenantSolution.Data;
using Microsoft.EntityFrameworkCore;
using MultiTenantSolution;
using MultiTenantSolution.Provider;
using MultiTenantSolution.Middlewares;
using MultiTenantSolution.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<TenantData>();

// Solução para IDs na tabela
//builder.Services.AddDbContext<AppDbContext>(p =>
//    p.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MultiTenantDb;Integrated Security=True")
//    .LogTo(Console.WriteLine)
//    .EnableSensitiveDataLogging());


// Multi-tenancy com banco de dados por tenant

builder.Services.AddHttpContextAccessor();

//Será resolvido em tempo de execução qual connection string usar, e assim o banco de dados de cada cliente, pelo tenant ID
builder.Services.AddScoped<AppDbContext>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

    var httpcontextAccessor = provider.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
    var tenantId = httpcontextAccessor?.GetTenantId();
    var connectionString = builder.Configuration.GetConnectionString(tenantId);

    optionsBuilder.UseSqlServer(connectionString)
    .LogTo(Console.WriteLine)
    .EnableSensitiveDataLogging();

    return new AppDbContext(optionsBuilder.Options);

});


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
