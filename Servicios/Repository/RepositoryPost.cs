using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistencia.Context;
using System.Security.Claims;
using System.Timers;

namespace Servicios.Repository
{

    public interface IRepositoryPost
    {
        Task addComent(Comentario comentario);
        Task Create(Post post);
        Task Delete(Post post);
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> GetPost(int? id);
        int GetUsuario();
        Task Update(Post post);
        Task<bool> VerificarExiste(int id);
    }
    public class RepositoryPost:IRepositoryPost
    {
        private readonly BlogPersonalContext _context;
        private readonly IHttpContextAccessor httpContext;

        public RepositoryPost(BlogPersonalContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            this.httpContext = httpContext;
        }

        public async Task<Post> GetPost(int? id)
        {

            var post = await _context.Posts.Include(c=>c.IdCategoriaNavigation)
                .Include(u=>u.IdUserNavigation).Include(coment=> coment.Comentarios).FirstOrDefaultAsync(x=>x.Id ==id);

            return post;
        }

        public async Task<IEnumerable<Post>> GetAll()
        {


            var post = await _context.Posts.Include(c => c.IdCategoriaNavigation).Include(u=> u.IdUserNavigation).ToListAsync();



            return post;


        }
        public async Task Create(Post post)
        {
            _context.Posts.Add(post);
           await _context.SaveChangesAsync();
        }

        public async Task<Post> GetById(int id)
        {

          return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p=> p.Id == id);
        }

        public async Task<bool> VerificarExiste(int id)
        {
           return await _context.Posts.AnyAsync(p=> p.Id == id);

        }

        public async Task Update(Post post)
        {

             _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post)
        {

            _context.Remove(post);
            await _context.SaveChangesAsync();

        }

        public int GetUsuario()
        {

            //validamos que exista un usario autenticado para cuando se valla a crear un comentario y no sea de un usuario autenticado
            //el usuario sea de id 0;

            if (httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var usuarioId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                return Int32.Parse(usuarioId);
            }

            return 0;
        }

        public async Task addComent(Comentario comentario)
        {

            _context.Add(comentario);

            await _context.SaveChangesAsync();
        }
      
    }
}
