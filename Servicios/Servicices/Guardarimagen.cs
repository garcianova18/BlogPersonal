
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
        Task<string> GuardarImagenes(PostViewModel post);
    }
    public class Guardarimagen:IGuardarimagen
    {


        public async Task< string >GuardarImagenes(PostViewModel post)
        {

            //obtener nombre y extension del File para gardar como string en Db

            string FileName = Path.GetFileNameWithoutExtension(post.Imagen.FileName);
            string Extension = Path.GetExtension(post.Imagen.FileName);
            string ImagenName = FileName + Extension;

            //Guadar file en directorio wwroot/imagenes

            string Ruta = "./wwwroot/imagenes" + FileName + Extension;

            using (FileStream stream = new FileStream(Ruta, FileMode.Create))
            {
                await post.Imagen.CopyToAsync(stream);
            }

            return ImagenName;
        }
    }
}
