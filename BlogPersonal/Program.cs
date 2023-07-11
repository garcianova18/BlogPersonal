using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using Servicios.Repository;
using Servicios.Servicices.Interfaces;
using Servicios.Servicices.Implementaciones;
using Servicios.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BlogPersonalContext>(op=>op.UseSqlServer(builder.Configuration.GetConnectionString("conexion")));
builder.Services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));


builder.Services.AddAutoMapper(typeof(ProfileConfig));

builder.Services.AddScoped<IServicicesComboBox, ServicicesComboBox>();

builder.Services.AddScoped<IGuardarimagen, Guardarimagen>();

builder.Services.AddScoped<IServicesPost, ServicesPost>();

builder.Services.AddScoped<IServicesPaginacionDetails, ServicesPaginacionDetails>();

builder.Services.AddScoped<IServicesUsuario, ServicesUsuario>();

builder.Services.AddScoped<IServicesComment, ServicesComment>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(op =>
{

    op.LoginPath = "/Acceso/Login";
    op.AccessDeniedPath = "/Acceso/Restringido";
});

builder.Services.AddHttpContextAccessor();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=Index}/{id?}");

app.Run();
