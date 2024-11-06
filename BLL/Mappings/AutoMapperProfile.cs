using AutoMapper;
using BLL.Dtos;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappings
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bill,BillDto>().ReverseMap();
            CreateMap<Cart,CartDto>().ReverseMap();
            CreateMap<CartItem,CartItemDto>().ReverseMap();
            CreateMap<Category,CategoryDto>().ReverseMap();
            CreateMap<Comment,CommentDto>().ReverseMap();
            CreateMap<Gender,GenderDto>().ReverseMap();
            CreateMap<Log,LogDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<OrderItem,OrderItemDto>().ReverseMap();
            CreateMap<Payment,PaymentDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<ProductDetail,ProductDetailDto>().ReverseMap();
            CreateMap<ProductLike,ProductLikeDto>().ReverseMap();
            CreateMap<UserDetail,UserDetailDto>().ReverseMap();
            CreateMap<User,UserDto>().ReverseMap();
            CreateMap<UserRole,UserRoleDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Card, CardDto>().ReverseMap();


        }
    }
}
