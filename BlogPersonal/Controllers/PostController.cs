
using AutoMapper;
using Dominio.Models;
using DTOs.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicios.Repository;
using Servicios.Servicices;
using System.Linq;
using System.Security.Claims;

namespace BlogPersonal.Controllers
{

    public class PostController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly IMapper _mapper;
        private readonly IServicicesComboBox comboBox;
        private readonly IGuardarimagen guardarimagen;
        private readonly IServicioPaginacionDetails paginacionDetails;
        private readonly IServicesComment _servicesComment;
        private readonly IRepositoryPost _repository;
        public PostController(IRepositoryPost repository, IWebHostEnvironment environment, IMapper mapper,
            IServicicesComboBox comboBox, IGuardarimagen guardarimagen, IServicioPaginacionDetails paginacionDetails,
            IServicesComment servicesComment)
        {
            this.environment = environment;
            _mapper = mapper;
            this.comboBox = comboBox;
            this.guardarimagen = guardarimagen;
            this.paginacionDetails = paginacionDetails;
            this._servicesComment = servicesComment;
            _repository = repository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var post = await _repository.GetAllWithRelatedData();

            var PostMapper = _mapper.Map<List<PostVM>>(post);

            return View(PostMapper);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.IdCategoria = comboBox.ComboCategoria();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostVM post)
        {

            ViewBag.IdCategoria = comboBox.ComboCategoria();

            try
            {
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
            catch (Exception)
            {
                //aqui podemos devolver un mensaje personalizado a la vista
                //tambien podemos guardar log en db o directorio

                throw;
            }





        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            try
            {

                var post = await _repository.GetPostWithRelatedData(id.GetValueOrDefault());

                var PostMapper = _mapper.Map<DetailsPostVM>(post);

                if (post == null)
                {
                    return NotFound();
                }



                var ListPost = await _repository.GetAllWithRelatedData();

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
            catch (Exception)
            {

                throw;
            }

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

            try
            {
                var post = await _repository.GetById(id.GetValueOrDefault());

                if (post is null)
                {
                    return NotFound();
                }

                var postMapper = _mapper.Map<EditPostVM>(post);

                return View(postMapper);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPostVM postVM)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var postExiste = await _repository.VerificarExiste(postVM.Id);

                    if (!postExiste)
                    {
                        return NotFound();
                    }

                    var buscarImagen = await _repository.GetByIdAsNoTracking(postVM.Id);

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
            catch (Exception)
            {

                throw;
            }
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            try
            {

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


                await _repository.Delete(post);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {

                throw;
            }






        }

       
        

        [HttpPost, ActionName("Details")]
        public async Task<IActionResult> AddComent(DetailsPostVM comentatio, int? id)
        {
            if (id is null || id == 0)
            {
                NotFound();
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var coment = new Comentario
                    {
                        Descripcion = comentatio.Comentario.Descripcion,
                        IdPost = id.GetValueOrDefault(),
                        Nombre = comentatio.Comentario.Nombre,
                        FechaPublicado = DateTime.Now,
                        Status = 1
                    };

                    await _servicesComment.Create(coment);

                    return RedirectToAction(nameof(Details));

                }

                //como no traemos los datos del detalles lo volvemos a buscar para mostrarlo nuevamente
                var post = await _repository.GetPostWithRelatedData(id.GetValueOrDefault());

                var PostMapper = _mapper.Map<DetailsPostVM>(post);


                if (post == null)
                {
                    return NotFound();
                }

                //obtenemos el listado de Post para mostrarlo como articulos relacionados
                var ListPost = await _repository.GetAllWithRelatedData();

                var ListPostMapper = _mapper.Map<List<PostVM>>(ListPost);

                PostMapper.ListPostVMs = ListPostMapper;


                return View(nameof(Details), PostMapper);
            }
            catch (Exception)
            {

                throw;
            }


        }





    }
}
