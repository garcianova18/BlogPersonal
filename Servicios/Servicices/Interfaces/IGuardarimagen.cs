using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices.Interfaces
{
    public interface IGuardarimagen
    {
        Task<string> GuardarImagenes(IFormFile im);
    }
}
