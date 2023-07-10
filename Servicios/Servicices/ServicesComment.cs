using Dominio.Models;
using Servicios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Context;

namespace Servicios.Servicices
{
    public interface IServicesComment:IRepositoryGeneric<Comentario>
    {

    }
    public class ServicesComment:RepositoryGeneric<Comentario>, IServicesComment
    {
        private readonly BlogPersonalContext _context;

        public ServicesComment(BlogPersonalContext context): base(context) 
        {
            _context = context;
        }
    }
}
