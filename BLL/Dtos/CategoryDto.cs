using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CategoryDto:BaseEntityDto
    {
        public string Name { get; set; }

        public List<ProductDto> ProductDtos { get; set; }

    }
}

