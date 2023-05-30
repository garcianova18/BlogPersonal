
using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class DetailsPostVM:ListPostVM
    {
        public List<ListPostVM> ListPostVMs { get; set;}


        //Propiedad para crear un comentario
        public CrearComentarioVM Comentario { get; set; }


        //Propiedad para la apginacion Pagina Antetior
        public int PaginaAntetior { get; set; }


        //Propiedad para la apginacion Pagina Siguiente
        public int PaginaSiguiente { get; set; }



    }
}
