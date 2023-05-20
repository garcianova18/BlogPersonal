

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTO
{
    public class CreatePostVM
    {

        [Required (ErrorMessage ="El Titulo es obligatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; }

        public IFormFile ImagenFile { get; set; }

        [Required(ErrorMessage = "Debes elegir una Categorio")] 
        public int IdCategoria { get; set; }


    }
}
