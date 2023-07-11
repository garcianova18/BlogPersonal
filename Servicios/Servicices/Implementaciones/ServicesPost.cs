using Dominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistencia.Context;
using Servicios.Repository;
using Servicios.Servicices.Interfaces;
using System.Security.Claims;
using System.Timers;

namespace Servicios.Servicices.Implementaciones
{

   
    public class ServicesPost : RepositoryGeneric<Post>, IServicesPost
    {
        private readonly BlogPersonalContext _context;
        private readonly IHttpContextAccessor httpContext;

        public ServicesPost(BlogPersonalContext context, IHttpContextAccessor httpContext) : base(context)
        {
            _context = context;
            this.httpContext = httpContext;
        }

        public async Task<Post> GetPostWithRelatedData(int id)
        {

            return await _context.Posts.Include(c => c.IdCategoriaNavigation)
                .Include(u => u.IdUserNavigation).Include(coment => coment.Comentarios)
                .FirstOrDefaultAsync(x => x.Id == id);


        }

        public async Task<IEnumerable<Post>> GetAllWithRelatedData()
        {


            var post = await _context.Posts.Include(c => c.IdCategoriaNavigation).Include(u => u.IdUserNavigation).ToListAsync();



            return post;


        }


        public async Task<Post> GetByIdAsNoTracking(int id)
        {

            return await _context.Posts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> VerificarExiste(int id)
        {
            return await _context.Posts.AnyAsync(p => p.Id == id);

        }


        public int GetUsuario()
        {

            //validamos que exista un usario autenticado para cuando se valla a crear un comentario y no sea de un usuario autenticado
            //el usuario sea de id 0;

            if (httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var usuarioId = httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

                return int.Parse(usuarioId);
            }

            return 0;
        }



    }
}
