using BlogPersonal.Models;
using BlogPersonal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace BlogPersonal.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogPersonalContext _context;
        private readonly IHostEnvironment environment;

        public PostController(BlogPersonalContext context, IHostEnvironment environment )
        {
            _context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.IdCategoria = ComboCategoria();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel post)
        {

            ViewBag.IdCategoria = ComboCategoria();

            if (ModelState.IsValid)
            {
                var model = new Post();

                model.Titulo = post.Titulo;
                model.Descripcion = post.Descripcion;
                model.Status = 1;
                model.IdCategoria = post.IdCategoria;
                model.FechaPublicado = DateTime.Now;
                model.IdUser = 1;

                if (post.Imagen !=null) {

                     //Obetener el nombre y extension del archivo para gardar en DB como string
                    string FileName = Path.GetFileNameWithoutExtension(post.Imagen.FileName);
                    string  Extension = Path.GetExtension(post.Imagen.FileName);
                    model.Imagen = FileName + Extension;


                    // guardar imagene en la ruta wwwroot/Imagenes
                    string Ruta = "./wwwroot/imagenes/" + FileName + Extension;

                    using (FileStream stream = new FileStream(Ruta, FileMode.Create))
                    {
                       await post.Imagen.CopyToAsync(stream);
                    }
                }
                else
                {
                    model.Imagen = null;
                }
                

                _context.Add(model);
                _context.SaveChanges();
            }


            return View();
        }


        public List<SelectListItem> ComboCategoria()
        {

            var categoria = _context.Categoria.Select(c => new SelectListItem
            {
                Text = c.Nombre,
                Value = c.Id.ToString()
            }).ToList();

            
            return categoria;
        }
    }
}
