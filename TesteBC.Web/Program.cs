using TesteBC.Infrastructure.Repositories;
using TesteBC.Infrastructure.Repositories.Interfaces;
using TesteBC.Web.Services;
using TesteBC.Web.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<ILancamentoService, LancamentoService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:7092/api/");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});
builder.Services.AddHttpClient<IEntidadeService, EntidadeService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:7092/api/");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});
builder.Services.AddHttpClient<IReportService, ReportService>(c =>
{
    c.BaseAddress = new Uri("https://localhost:7092/api/");
    c.DefaultRequestHeaders.Add("Accept", "application/.json");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
