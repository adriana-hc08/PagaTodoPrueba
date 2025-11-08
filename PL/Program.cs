using DL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("AHernandezPrueba");

builder.Services.AddDbContext<AHernandezPruebaContex>(options => options.UseSqlServer(conString));


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
