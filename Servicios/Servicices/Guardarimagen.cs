
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTO;

namespace Servicios.Servicices
{

    public interface IGuardarimagen
    {
        Task<string> GuardarImagenes(CreatePostVM post);
    }
    public class Guardarimagen:IGuardarimagen
    {


        public async Task< string >GuardarImagenes(CreatePostVM post)
        {

            //obtener nombre y extension del File para gardar como string en Db

            string FileName = Path.GetFileNameWithoutExtension(post.Imagen.FileName);
            string Extension = Path.GetExtension(post.Imagen.FileName);
            string ImagenName = FileName + "_" + Guid.NewGuid() + Extension;

            //Guadar imagen en directorio wwwroot/imagenes

            string Ruta = "./wwwroot/imagenes/" + ImagenName;

            using (FileStream stream = new FileStream(Ruta, FileMode.Create))
            {
                await post.Imagen.CopyToAsync(stream);
            }

            return ImagenName;
        }
    }
}
