
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Servicios.Servicices
{

    public interface IGuardarimagen
    {
        Task<string> GuardarImagenes(IFormFile im);
    }
    public class Guardarimagen:IGuardarimagen
    {


        public Guardarimagen()
        {
         
        }

        public async Task< string >GuardarImagenes(IFormFile img )
        {

            //obtener nombre y extension del File para gardar como string en Db
            
            string FileName = Path.GetFileNameWithoutExtension(img.FileName);
            string Extension = Path.GetExtension(img.FileName);
            string ImagenName = FileName + "_" + Guid.NewGuid() + Extension;

            //Guadar imagen en directorio wwwroot/imagenes

            string Ruta = "./wwwroot/imagenes/" + ImagenName;

            using (FileStream stream = new FileStream(Ruta, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }

            return ImagenName;
        }
    }
}
