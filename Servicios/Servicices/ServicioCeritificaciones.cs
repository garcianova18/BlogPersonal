using DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices
{
    public interface IServicioCertificaciones
    {
        IEnumerable<Certificaciones> Certificaciones();
    }
    public class ServicioCeritificaciones: IServicioCertificaciones
    {


        public IEnumerable<Certificaciones> Certificaciones()
        {

            IEnumerable<Certificaciones> certificaciones = new List<Certificaciones>
            {

                new Certificaciones
                {
                    Titulo = "Ing. De Sistema y Computacion",
                    Foto = "ASPnetCore.jpg",
                    Centro = "Universidad O&M"

                },
                new Certificaciones
                {
                    Titulo = "Master en C# OOP",
                    Foto = "sqlserver.jpg",
                    Centro = "Udemy"

                },
                new Certificaciones
                {
                    Titulo = "Desarrollo Web JavaScript Moderno ",
                    Foto = "Javascript.jpg",
                    Centro = "Udemy"

                }
            };
          
            return certificaciones;
        }
    }
}
