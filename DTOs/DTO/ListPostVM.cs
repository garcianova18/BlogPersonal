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

        public int Status { get; set; }

        public string IdCategoriaNavigationNombre { get; set; }

        public string IdUserNavigationUserName { get; set; }

        public int IdCategoria { get; set; }

        public int IdUser { get; set; }

        public ICollection<Comentario> Comentarios { get; set; }
    }
}
