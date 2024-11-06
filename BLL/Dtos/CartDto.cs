﻿using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Dtos
{
    public class CartDto:BaseEntity
    {
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public List<CartItemDto> CartItemDtos { get; set; }
    }
}
