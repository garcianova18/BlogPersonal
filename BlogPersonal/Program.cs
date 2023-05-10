using BlogPersonal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using Servicios.Repository;
using Servicios.Servicices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogPersonalContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddTransient(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));


builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IServicicesComboBox, ServicicesComboBox>();
builder.Services.AddScoped<IGuardarimagen, Guardarimagen>();

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
    pattern: "{controller=Post}/{action=Create}/{id?}");

app.Run();
