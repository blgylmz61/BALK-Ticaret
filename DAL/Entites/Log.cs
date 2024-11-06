using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Log:BaseEntity
    {
        
        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
    }
}
