﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTO
{
    public class DetailsPostVM:ListPostVM
    {
        public List<ListPostVM> ListPostVMs { get; set;}
    }
}