

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DTOs.DTO
{
    public class CreatePostVM
    {

        [Required (ErrorMessage ="El Titulo es obligatorio")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name ="Foto")]
        public IFormFile ImagenFile { get; set; }

        [Required(ErrorMessage = "Debes elegir una Categorio")]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }


    }
}
