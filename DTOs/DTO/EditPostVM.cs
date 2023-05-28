using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class EditPostVM
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public DateTime FechaPublicado { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

    
        public string Imagen { get; set; }

        [Display(Name = "Foto")]
        public IFormFile ImagenFile { get; set; }
        
        public int Status { get; set; }

        [Display(Name = "Categoría")]
        [Required]
        public int IdCategoria { get; set; }
    }
}
