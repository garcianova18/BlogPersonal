

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTO
{
    public class CreatePostVM
    {

        [Required]
        public string Titulo { get; set; } = null!;
      
        public string Descripcion { get; set; }

        public IFormFile ImagenFile { get; set; }

        [Required] 
        public int IdCategoria { get; set; }


    }
}
