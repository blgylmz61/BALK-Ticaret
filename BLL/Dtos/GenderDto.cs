using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class GenderDto:BaseEntityDto
    {
        public string Name { get; set; }
        public UserDetailDto UserDetail { get; set; }
    }
}
