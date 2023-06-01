
using AutoMapper;
using Dominio.Models;
using DTOs.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Repository;
using Servicios.Servicices;
using System.Linq;

namespace BlogPersonal.Controllers
{
   
    public class PostController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly IMapper _mapper;
        private readonly IServicicesComboBox comboBox;
        private readonly IGuardarimagen guardarimagen;
        private readonly IServicioPaginacionDetails paginacionDetails;
        private readonly IRepositoryPost _repository;
        public PostController(IRepositoryPost repository, IWebHostEnvironment environment, IMapper mapper, IServicicesComboBox comboBox, IGuardarimagen guardarimagen,IServicioPaginacionDetails paginacionDetails)
        {
            this.environment = environment;
            _mapper = mapper;
            this.comboBox = comboBox;
            this.guardarimagen = guardarimagen;
            this.paginacionDetails = paginacionDetails;
            _repository = repository;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var post = await _repository.GetAll();

            var PostMapper = _mapper.Map<List<PostVM>>(post);

            return View(PostMapper);
        }

        [Authorize]
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
                postMapper.IdUser = _repository.GetUsuario();


                if (post.ImagenFile is not null)
                {


                    postMapper.Imagen = await guardarimagen.GuardarImagenes(post.ImagenFile);


                }


                await _repository.Create(postMapper);

                return RedirectToAction("Index");
            }




            return View(post);
        }


        public async Task<IActionResult> Details(int? id)
        {



            if (id is null || id == 0)
            {
                return NotFound();
            }


            var post = await _repository.GetPost(id);

            var PostMapper = new DetailsPostVM();

            try
            {
                 PostMapper = _mapper.Map<DetailsPostVM>(post);
            }
            catch (Exception )
            {

                throw;
            }
           ;
            if (post == null)
            {
                return NotFound();
            }

           

            List<Post> ListPost = (List<Post>)await _repository.GetAll();

           // articulos relacionados
            var ListPostRecientesMapper = _mapper.Map<List<PostVM>>(ListPost);

            PostMapper.ListPostVMs = ListPostRecientesMapper.OrderByDescending(x => x.FechaPublicado).Take(5).ToList();



            //Servicio de paginacion

            var paginacion = paginacionDetails.PaginacionDetails(ListPostRecientesMapper, id.GetValueOrDefault());

            PostMapper.PaginaAntetior = paginacion.PaginaAntetior;
            PostMapper.PaginaSiguiente = paginacion.PaginaSiguiente;
            PostMapper.PaginaActual = paginacion.PaginaActual;
            return View(PostMapper);

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize]
        public async Task<IActionResult> Edit(EditPostVM postVM)
        {
            if (ModelState.IsValid)
            {

                var postExiste = await _repository.VerificarExiste(postVM.Id);

                if (!postExiste)
                {
                    return NotFound();
                }

                var buscarImagen = await _repository.GetById(postVM.Id);

                var postMapper = _mapper.Map<Post>(postVM);

                if (postVM.ImagenFile is not null)
                {
                    //si se seleciono una imagen para actualizar Eliminamos la imagen anterior

                    var buscarRutaImg = environment.WebRootPath + "/imagenes/" + buscarImagen.Imagen;

                    //si la ruta es valida eliminamos la imagen
                    if (System.IO.File.Exists(buscarRutaImg))
                    {
                        System.IO.File.Delete(buscarRutaImg);

                    }
                    //guardamos la nueva imagen en el directorio y obtenemos la ruta para guaradar en db
                    postMapper.Imagen = await guardarimagen.GuardarImagenes(postVM.ImagenFile);

                }
                else
                {


                    //si entra aqui fue que no se seleccionno una nueva imagen y le dejamos la que tenia
                    //ojo detener si no tenia pues se guarda como esta sin imagen

                    postMapper.Imagen = buscarImagen.Imagen;


                }

                //le pasamos la fecha de cuando se creo ya que esta no sera modificada
                postMapper.FechaPublicado = buscarImagen.FechaPublicado;
                postMapper.Status = 1;
                postMapper.IdUser = _repository.GetUsuario();
                await _repository.Update(postMapper);

                return RedirectToAction("Index");

            }

            return View(postVM);
        }


        [Authorize (Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var post = await _repository.GetById(id.GetValueOrDefault());

            if (post is null)
            {
                return NotFound();

            }

            //si existe una imagen la vamos a eliminar 
            if (post.Imagen is not null)
            {
                var ruta = environment.WebRootPath + "/Imagenes";
                var rutarutaNameImg = Path.Combine(ruta, post.Imagen);

                if (System.IO.File.Exists(rutarutaNameImg))
                {
                    System.IO.File.Delete(rutarutaNameImg);
                }
            }

            try
            {
                await _repository.Delete(post);
            }
            catch (Exception)
            {

                throw;
            }



            return RedirectToAction(nameof(Index));


        }

        [HttpPost, ActionName("Details")]
        public async Task<IActionResult> AddComent(DetailsPostVM comentatio, int? id)
        {
            if (id is null || id == 0)
            {
                NotFound();
            }

            if (ModelState.IsValid)
            {
                var coment = new Comentario();

                coment.Descripcion = comentatio.Comentario.Descripcion;
                coment.IdPost = id.GetValueOrDefault();

                //si el usuario es registrado enviamos su id si no enviamos null
                coment.IdUser = _repository.GetUsuario() == 0 ? null : _repository.GetUsuario();
                coment.Nombre = comentatio.Comentario.Nombre;
                coment.FechaPublicado = DateTime.Now;
                coment.Status = 1;

                await _repository.addComent(coment);

                return RedirectToAction(nameof(Details));

            }

            //como no traemos los datos del detalles lo volvemos a buscar para mostrarlo nuevamente
            var post = await _repository.GetPost(id);

            var PostMapper = _mapper.Map<DetailsPostVM>(post);


            if (post == null)
            {
                return NotFound();
            }

            //obtenemos el listado de Post para mostrarlo como articulos relacionados
            var ListPost = await _repository.GetAll();

            var ListPostMapper = _mapper.Map<List<PostVM>>(ListPost);

            PostMapper.ListPostVMs = ListPostMapper;


            return View(nameof(Details), PostMapper);


        }





    }
}
