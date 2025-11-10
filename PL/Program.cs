using DL;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("AHernandezPrueba");

builder.Services.AddDbContext<AHernandezPruebaContex>(options => options.UseSqlServer(conString));

builder.Services.AddHttpClient();


builder.Services.AddScoped<DL.Interfaces.ITareaRepository, DL.Interfaces.TareaRepository>();
builder.Services.AddScoped<DL.Interfaces.IStatusRepository, DL.Interfaces.StatusRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<BL.Tarea>();
builder.Services.AddScoped<BL.Status>();
//builder.Services.AddScoped<IConfiguration>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
