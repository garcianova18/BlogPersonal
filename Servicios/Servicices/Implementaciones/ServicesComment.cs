using Dominio.Models;
using Servicios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Context;
using Servicios.Servicices.Interfaces;

namespace Servicios.Servicices.Implementaciones
{
   
    public class ServicesComment : RepositoryGeneric<Comentario>, IServicesComment
    {
        private readonly BlogPersonalContext _context;

        public ServicesComment(BlogPersonalContext context) : base(context)
        {
            _context = context;
        }
    }
}
