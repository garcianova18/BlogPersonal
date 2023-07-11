using Dominio.Models;
using Servicios.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices.Interfaces
{
    public interface IServicesPost : IRepositoryGeneric<Post>
    {



        Task<IEnumerable<Post>> GetAllWithRelatedData();
        Task<Post> GetByIdAsNoTracking(int id);
        Task<Post> GetPostWithRelatedData(int id);
        int GetUsuario();
        Task<bool> VerificarExiste(int id);

    }
}
