using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class ProyectosCertificados
    {
        public IEnumerable<Certificaciones> Certificaciones { get;set; }
        public IEnumerable<Proyectos> Proyectos { get;set; }    
    }
}
