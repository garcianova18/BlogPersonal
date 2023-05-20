using Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class ListPostVM
    {

        public int Id { get; set; }
        public string Titulo { get; set; }

        public DateTime FechaPublicado { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public string IdCategoriaNavigationNombre { get; set; }

        public string IdUserNavigationUserName { get; set; }

        public int IdCategoria { get; set; }

        public int IdUser { get; set; }

        //Porpiedad para mostrar el listado de Comentarios que pertenecen a un Post en la vista Detalils
        public List<Comentario> ListComentarios { get; set; }




    }
}
