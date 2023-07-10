
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;



namespace Servicios.Repository
{
   
    public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
    {
        private readonly BlogPersonalContext _Context;
        private DbSet<T> entities;
        public RepositoryGeneric(BlogPersonalContext context)
        {
            _Context = context;
            entities = _Context.Set<T>();
        }
        public async Task Create(T entity)
        {
            try
            {
               await _Context.AddAsync(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task Delete(T entity)
        {
            try
            {
                entities.Remove(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           
                return await entities.ToListAsync();
           
        }

        public async Task<T> GetById(int? id)
        {
            return await entities.FindAsync(id);    
        }

        public async Task Update(T entity)
        {
            try
            {
                entities.Update(entity);
                await _Context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
          
        }
    }
}
