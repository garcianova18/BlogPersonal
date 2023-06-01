using AutoMapper;
using Dominio.Models;
using DTOs.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Servicios.Servicices;
using System.Security.Claims;

namespace BlogPersonal.Controllers
{
    public class AccesoController : Controller
    {
        private readonly IHttpContextAccessor httpContext;
        private readonly IServicioUsuario servicioUsuario;
        private readonly IMapper mapper;

        public AccesoController(IHttpContextAccessor httpContext, IServicioUsuario servicioUsuario, IMapper mapper)
        {
            this.httpContext = httpContext;
            this.servicioUsuario = servicioUsuario;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult>Login(UserLoginVM userLogin)
        {

            var usuarioMapper = mapper.Map<Dominio.Models.User>(userLogin);

            var usuario = await servicioUsuario.GetUser(usuarioMapper);

            if (usuario is not null)
            {
                var claims = new List<Claim> {

                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.UserName),
                    new Claim(ClaimTypes.Role, usuario.IdRolNavigation.Nombre),
                    new Claim("nombreUsuario", usuario.Nombre),
                 };


            var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

            return RedirectToAction("Index","Post");
            }

            ViewBag.errorusuario = "El usuario o contraseña que has ingresado es incorrecto vuelva a intentarlo";


            return View(nameof(Index));

        }


        public async Task<IActionResult> Logout()
        {

            await httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Post");
        }

        public IActionResult Restringido()
        {


            return View();
        }
    }


}
