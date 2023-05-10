﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicios.Servicices
{
    public interface IServicicesComboBox
    {
        List<SelectListItem> ComboCategoria();
    }
    public class ServicicesComboBox: IServicicesComboBox
    {
        private readonly BlogPersonalContext _context;


        public ServicicesComboBox(BlogPersonalContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ComboCategoria()
        {

            var categoria = _context.Categoria.Select(c => new SelectListItem
            {
                Text = c.Nombre,
                Value = c.Id.ToString()
            }).ToList();


            return categoria;
        }


    }
}
