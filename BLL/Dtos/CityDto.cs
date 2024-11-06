﻿using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CityDto:BaseEntityDto
    {
        public string? Name { get; set; }
        public int? CountryId { get; set; }
        public CountryDto? CountryDto { get; set; }
        public List<DistrictDto>? DistrictDtos { get; set; }

    }
}
