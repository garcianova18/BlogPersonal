
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class DetailsPostVM:PostVM
    {

        //propiedad para mostrar el listado de articulos relacionados
        public List<PostVM> ListPostVMs { get; set;}


        //Propiedad para crear un comentario
        public CrearComentarioVM Comentario { get; set; }


        //Propiedad para la paginacion Pagina Antetior
        public int PaginaAntetior { get; set; }


        //Propiedad para la paginacion Pagina Siguiente
        public int PaginaSiguiente { get; set; }

        //Propiedad para la paginacion Pagina Actual
        public int PaginaActual { get; set; }

        //Porpiedad para mostrar el listado de Comentarios que pertenecen a un Post en la vista Detalils
        public ICollection<Comentario> ListComentarios { get; set; }
    }
}
