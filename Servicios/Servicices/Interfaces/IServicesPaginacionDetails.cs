using DTOs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices.Interfaces
{
    public interface IServicesPaginacionDetails
    {
        DetailsPostVM PaginacionDetails(List<PostVM> ListPost, int id);
    }
}
