using DL;
using DL.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecific";

var conString = builder.Configuration.GetConnectionString("AHernandezPrueba");

builder.Services.AddDbContext<AHernandezPruebaContex>(options => options.UseSqlServer(conString));


builder.Services.AddScoped<DL.Interfaces.ITareaRepository, DL.Interfaces.TareaRepository>();
builder.Services.AddScoped<DL.Interfaces.IStatusRepository,DL.Interfaces.StatusRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<BL.Tarea>();
builder.Services.AddScoped<BL.Status>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5153")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
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

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
