using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IProductLikeService
    {
        Task CreateLike(ProductLikeDto productLikeDto);

        Task DeleteLike(int productLikeId);
        Task<ProductLikeDto> GetLikeByProductId(int productId);
        Task<ProductLikeDto> GetLikeByUserId(int userId);
        Task<ProductLikeDto> GetLikeById(int productLikeId);

        Task<List<ProductLikeDto>> GetAllLike();
        Task HasLikeByUserOnProduct(int userId,int productId);
    }
}
