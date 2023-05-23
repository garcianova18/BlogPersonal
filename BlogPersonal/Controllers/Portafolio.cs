using DTOs.DTO;
using Microsoft.AspNetCore.Mvc;
using Servicios.Servicices;

namespace BlogPersonal.Controllers
{
    public class Portafolio : Controller
    {
        private readonly IServicioProyectos servicioProyectos;

        public Portafolio(IServicioProyectos servicioProyectos)
        {
            this.servicioProyectos = servicioProyectos;
        }
        public IActionResult Index()
        {
            var servicio = servicioProyectos.Proyectos();

            return View(servicio);
        }

        
    }
}
