using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace Servicios.Servicices
{

    public interface IServicioUsuario
    {
        Task<User> GetUser(User user);
    }
    public class ServicioUsuario: IServicioUsuario
    {
        private readonly BlogPersonalContext context;

        public ServicioUsuario(BlogPersonalContext context)
        {
            this.context = context;
        }



        public async Task<User> GetUser(User user)
        {
            var usuario = await context.Users.Include(rol=> rol.IdRolNavigation) .FirstOrDefaultAsync(u=>u.UserName == user.UserName && u.Password == user.Password);

            return usuario;


        }
    }
}
