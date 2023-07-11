using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicices.Interfaces
{
    public interface IServicicesComboBox
    {
        List<SelectListItem> ComboCategoria();
    }
}
