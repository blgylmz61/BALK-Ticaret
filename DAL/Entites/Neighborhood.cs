﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Neighborhood:BaseEntity
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
