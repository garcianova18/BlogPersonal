
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;



namespace Servicios.Repository
{
   
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly BlogPersonalContext _Context;
        DbSet<T> Entity;
        public RepositoryGeneric(BlogPersonalContext context)
        {
            _Context = context;
            Entity = _Context.Set<T>();
        }
        public async Task Create(T entity)
        {
            try
            {
                _Context.Add(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task Delete(int? id)
        {
            _Context.Remove(id);
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
         return await Entity.ToListAsync();
        }

        public async Task<T> GetById(int? id)
        {
            return await Entity.FindAsync(id);    
        }

        public async Task Update(T entity)
        {
            try
            {
                _Context.Update(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
