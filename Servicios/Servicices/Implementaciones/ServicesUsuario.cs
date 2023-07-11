using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.Context;
using Microsoft.EntityFrameworkCore;
using Servicios.Servicices.Interfaces;

namespace Servicios.Servicices.Implementaciones
{

   
    public class ServicesUsuario : IServicesUsuario
    {
        private readonly BlogPersonalContext context;

        public ServicesUsuario(BlogPersonalContext context)
        {
            this.context = context;
        }



        public async Task<User> GetUser(User user)
        {
            var usuario = await context.Users.Include(rol => rol.IdRolNavigation).FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);

            return usuario;


        }
    }
}
