using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class LogDto:BaseEntityDto
    {
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}
