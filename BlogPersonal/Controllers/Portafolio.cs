using DTOs.DTO;
using Microsoft.AspNetCore.Mvc;
using Servicios.Servicices;

namespace BlogPersonal.Controllers
{
    public class Portafolio : Controller
    {
        private readonly IServicioProyectos servicioProyectos;
        private readonly IServicioCertificaciones certificaciones;

        public Portafolio(IServicioProyectos servicioProyectos, IServicioCertificaciones certificaciones)
        {
            this.servicioProyectos = servicioProyectos;
            this.certificaciones = certificaciones;
        }
        public IActionResult Index()
        {

            var proyectosCertificados = new ProyectosCertificados();

            proyectosCertificados.Proyectos = servicioProyectos.Proyectos();


            proyectosCertificados.Certificaciones = certificaciones.Certificaciones();



            return View(proyectosCertificados);
        }

        
    }
}
