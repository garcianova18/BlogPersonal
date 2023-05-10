using BlogPersonal.Models;
using Microsoft.Build.Framework;

namespace BlogPersonal.ViewModels
{
    public class PostViewModel
    {

        [Required]
        public string Titulo { get; set; } = null!;
      
        public string Descripcion { get; set; }

        public IFormFile Imagen { get; set; }

        public int Status { get; set; }

        [Required] 
        public int IdCategoria { get; set; }


    }
}
