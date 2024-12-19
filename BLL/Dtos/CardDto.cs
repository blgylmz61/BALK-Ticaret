using DAL.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CardDto : BaseEntityDto
    {
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
