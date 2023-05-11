using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;



namespace Servicios.Repository
{

    public interface IRepositoryPost
    {
        Task Create(Post post);
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetPost(int? id);
    }
    public class RepositoryPost:IRepositoryPost
    {
        private readonly BlogPersonalContext _context;
        public RepositoryPost(BlogPersonalContext context)
        {
            _context = context;
        }

        public async Task<Post> GetPost(int? id)
        {

            var post = await _context.Posts.Include(c=>c.IdCategoriaNavigation).FirstOrDefaultAsync(x=>x.Id ==id);

            return post;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {


            var post = await  _context.Posts.Include(c=> c.IdCategoriaNavigation).ToListAsync();

           

            return post;


        }
        public async Task Create(Post post)
        {
            _context.Posts.Add(post);
           await _context.SaveChangesAsync();
        }

      
    }
}
