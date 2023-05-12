﻿using Dominio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Persistencia.Context;



namespace Servicios.Repository
{

    public interface IRepositoryPost
    {
        Task Create(Post post);
        Task<IEnumerable<Post>> GetAll();
        Task<Post> GetById(int id);
        Task<Post> GetPost(int? id);
        Task Update(Post post);
        Task<bool> VerificarExiste(int id);
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

        public async Task<Post> GetById(int id)
        {

          return await _context.Posts.FindAsync(id);
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

      
    }
}
