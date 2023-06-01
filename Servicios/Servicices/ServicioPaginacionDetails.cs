using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTO;

namespace Servicios.Servicices
{

    public interface IServicioPaginacionDetails
    {
        DetailsPostVM PaginacionDetails(List<PostVM> ListPost, int id);
    }
    public class ServicioPaginacionDetails:IServicioPaginacionDetails
    {

        public  DetailsPostVM PaginacionDetails(List<PostVM> ListPost, int id)
        {

            int indexPaginaAnterior, indexPaginaSiguiente, indexPaginaActual = ListPost.FindIndex(x => x.Id == id);



            indexPaginaAnterior = indexPaginaActual == 0 ? indexPaginaActual : indexPaginaActual - 1;



            indexPaginaSiguiente = indexPaginaActual == ListPost.Count - 1 ? indexPaginaActual : indexPaginaActual + 1;



            var detailPost = new DetailsPostVM();

            detailPost.PaginaActual = id;
            detailPost.PaginaAntetior = ListPost[indexPaginaAnterior].Id;
            detailPost.PaginaSiguiente = ListPost[indexPaginaSiguiente].Id;



            return detailPost;
        }
    }
}
