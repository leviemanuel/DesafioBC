using Microsoft.EntityFrameworkCore;
using TesteBC.Service.Interfaces;
using TesteBC.Service;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var cn = builder.Configuration.GetConnectionString("defaultCon");
builder.Services.AddDbContext<TesteBC.Infrastructure.Data.Context.TesteBCDBContext>(opts => opts.UseLazyLoadingProxies().UseMySql(cn, ServerVersion.AutoDetect(cn)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ILancamentoService, LancamentoService>();
builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();
builder.Services.AddScoped<IEntidadeService, EntidadeService>();
builder.Services.AddScoped<IEntidadeRepository, EntidadeRepository>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
