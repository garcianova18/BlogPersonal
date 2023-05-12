
using AutoMapper;
using Dominio.Models;
using DTOs.DTO;
using Microsoft.AspNetCore.Mvc;
using Servicios.Repository;
using Servicios.Servicices;


namespace BlogPersonal.Controllers
{
    public class PostController : Controller
    {
        private readonly IHostEnvironment environment;
        private readonly IMapper _mapper;
        private readonly IServicicesComboBox comboBox;
        private readonly IGuardarimagen guardarimagen;
        private readonly IRepositoryPost _repository;
        public PostController(IRepositoryPost repository, IHostEnvironment environment, IMapper mapper, IServicicesComboBox comboBox, IGuardarimagen guardarimagen)
        {
            this.environment = environment;
            _mapper = mapper;
            this.comboBox = comboBox;
            this.guardarimagen = guardarimagen;
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var post = await _repository.GetAll();

            var PostMapper = _mapper.Map<List<ListPostVM>>(post);

            return View(PostMapper);
        }

        public IActionResult Create()
        {
            ViewBag.IdCategoria = comboBox.ComboCategoria();


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostVM post)
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

                return RedirectToAction("Index");
            }




            return View(post);
        }


        public async Task<IActionResult> Details(int? id)
        {

            if (id is null || id ==0)
            {
                return NotFound();
            }

            var post = await _repository.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }
            var PostMapper = _mapper.Map<ListPostVM>(post);

            return View(PostMapper);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.IdCategoria = comboBox.ComboCategoria();

            if (id is null || id == 0)
            {

                return NotFound();
            }

            var post = await _repository.GetById(id.GetValueOrDefault());
            if (post is null)
            {
                return NotFound();
            }

            var postMapper = _mapper.Map<EditPostVM>(post);

            return View(postMapper);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostVM postVM)
         {
            if (ModelState.IsValid)
            {
               
               var post = await _repository.VerificarExiste(postVM.Id);
                if (!post)
                {
                    return NotFound();
                }

               
                if (postVM.ImagenFile is null)
                {
                    var postMapper = _mapper.Map<Post>(postVM);

                    postMapper.Status = 1;
                    postMapper.IdUser = 1;
                    postMapper.FechaPublicado = DateTime.Now;
                    await _repository.Update(postMapper);

                    return RedirectToAction("Index");
                }

               
            }

            return View(postVM);
        }

    }
}
