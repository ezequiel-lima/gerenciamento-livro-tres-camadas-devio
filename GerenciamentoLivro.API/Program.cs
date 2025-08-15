using GerenciamentoLivro.API.Configurations;
using GerenciamentoLivro.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<GerenciamentoLivroDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.ResolveDependencies();

builder.AddSwaggerConfiguration();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
