using DL;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("AHernandezPrueba");

builder.Services.AddDbContext<AHernandezPruebaContex>(options => options.UseSqlServer(conString));

builder.Services.AddScoped<BL.Tarea>();
builder.Services.AddScoped<BL.Status>();
builder.Services.AddScoped<DL.Interfaces.ITareaRepository, DL.Interfaces.TareaRepository>();
builder.Services.AddScoped<DL.Interfaces.IStatusRepository, DL.Interfaces.StatusRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
