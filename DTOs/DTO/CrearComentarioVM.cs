using Dominio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class CrearComentarioVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="No puedes agregar un comentario vacio")]
        public string Descripcion { get; set; } = null!;

        public DateTime FechaPublicado { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }

        public int Status { get; set; }

      
    }
}
