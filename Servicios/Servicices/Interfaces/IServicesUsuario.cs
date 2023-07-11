using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices.Interfaces
{
    public interface IServicesUsuario
    {
        Task<User> GetUser(User user);
    }
}
