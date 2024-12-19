using AutoMapper;
using BALK_Ticaret.Models;
using BLL.Dtos;
using DAL.Entites;


namespace BALK_Ticaret.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<BillViewModel, BillDto>().ReverseMap();
            CreateMap<CartViewModel, CartDto>().ReverseMap();
            CreateMap<CartItemViewModel, CartItemDto>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDto>().ReverseMap();
            CreateMap<CommentViewModel, CommentDto>().ReverseMap();
            CreateMap<GenderViewModel, GenderDto>().ReverseMap();
            CreateMap<LogViewModel, LogDto>().ReverseMap();
            CreateMap<OrderViewModel, OrderDto>().ReverseMap();
            CreateMap<OrderItemViewModel, OrderItemDto>().ReverseMap();
            CreateMap<PaymentViewModel, PaymentDto>().ReverseMap();
            CreateMap<ProductViewModel, ProductDto>().ReverseMap();
            CreateMap<ProductDetailViewModel, ProductDetailDto>().ReverseMap();
            CreateMap<ProductLikeViewModel, ProductLikeDto>().ReverseMap();
            CreateMap<UserDetailViewModel, UserDetailDto>().ReverseMap();
            CreateMap<UserViewModel, UserDto>().ReverseMap();
            CreateMap<UserRoleViewModel, UserRoleDto>().ReverseMap();
            CreateMap<CountryViewModel, CountryDto>().ReverseMap();
            CreateMap<CityViewModel, CityDto>().ReverseMap();
            CreateMap<DistrictViewModel, DistrictDto>().ReverseMap();
            CreateMap<CardViewModel, CardDto>().ReverseMap();
            CreateMap<NeighborhoodViewModel, NeighborhoodDto>().ReverseMap();


        }
    }
}
