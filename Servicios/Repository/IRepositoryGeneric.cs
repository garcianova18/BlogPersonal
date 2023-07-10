using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Repository
{
    public interface IRepositoryGeneric< T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int? id);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
