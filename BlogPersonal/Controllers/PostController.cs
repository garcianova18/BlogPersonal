
using AutoMapper;
using Dominio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Persistencia.Context;
using Servicios.Repository;
using Servicios.Servicices;
using System.Reflection.Metadata;
using DTOs.DTO;


namespace BlogPersonal.Controllers
{
    public class PostController : Controller
    {
        private readonly IHostEnvironment environment;
        private readonly IMapper _mapper;
        private readonly IServicicesComboBox comboBox;
        private readonly IGuardarimagen guardarimagen;
        private readonly IRepositoryGeneric<Post> _repository;
        public PostController( IRepositoryGeneric<Post> repository, IHostEnvironment environment, IMapper mapper, IServicicesComboBox comboBox, IGuardarimagen guardarimagen)
        {
            this.environment = environment;
            _mapper = mapper;
            this.comboBox = comboBox;
            this.guardarimagen = guardarimagen;
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewBag.IdCategoria = comboBox.ComboCategoria();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel post)
        {

            ViewBag.IdCategoria = comboBox.ComboCategoria();

            if (ModelState.IsValid)
            {

                var postMapper = _mapper.Map<Post>(post);

                postMapper.Status = 1;
                postMapper.FechaPublicado = DateTime.Now;
                postMapper.IdUser = 1;


                if (post.Imagen != null)
                {


                  postMapper.Imagen = await guardarimagen.GuardarImagenes(post);

                   
                }


               await _repository.Create(postMapper);

            }




            return View(post);
        }


      

    }
}
