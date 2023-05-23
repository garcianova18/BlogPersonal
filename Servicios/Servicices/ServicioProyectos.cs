using DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices
{
    public interface IServicioProyectos
    {
        IEnumerable<Proyectos> Proyectos();
    }
    public class ServicioProyectos: IServicioProyectos
    {
        public ServicioProyectos()
        {

        }

        public IEnumerable<Proyectos> Proyectos()
        {

            IEnumerable<Proyectos> proyectos = new List<Proyectos>()
            {


                new Proyectos
                {
                    Titulo="Agenda Telefonica",
                    Descripcion="En ella almacenamos los contacto de los usuarios, Creada en asp.net core 3.1",
                    Imagen ="./wwwroot/imagenes/proyectos/AgendaTelefonica.JPG",
                    Url="http://www.agendacgi.somee.com/Electromecanica"
                },
                 new Proyectos
                {
                    Titulo="Agenda Telefonica",
                    Descripcion="En ella almacenamos los contacto de los usuarios, Creada en asp.net core 3.1",
                    Imagen ="~/wwwroot/imagenes/proyectos/AgendaTelefonica",
                    Url="http://www.agendacgi.somee.com/Electromecanica"
                },
                  new Proyectos
                {
                    Titulo="Agenda Telefonica",
                    Descripcion="En ella almacenamos los contacto de los usuarios, Creada en asp.net core 3.1",
                    Imagen ="~/wwwroot/imagenes/proyectos/AgendaTelefonica",
                    Url="http://www.agendacgi.somee.com/Electromecanica"
                }
            };



            return proyectos;
        }


    }
}
