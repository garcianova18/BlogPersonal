using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class EditPostVM
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public DateTime FechaPublicado { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public IFormFile ImagenFile { get; set; }
        
        public int Status { get; set; }

        public int IdCategoria { get; set; }
    }
}
