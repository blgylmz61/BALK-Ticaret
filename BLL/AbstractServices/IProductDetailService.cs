using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IProductDetailService
    {
        Task CreateProductDetail(ProductDetailDto productDetailDto); 
        Task DeleteProductDetail(int productDetailId);
        Task UpdateProductDetail(ProductDetailDto productDetailDto);
        Task<ProductDetailDto> GetProductDetailById(int productDetailId);
        Task<List<ProductDetailDto>> GetProductDetailAll();
        Task<IEnumerable<ProductDetailDto>> GetProductDetailByConditionAsync(Expression<Func<ProductDetailDto, bool>> predicate);
        Task<ProductDetailDto> GetProductDetailWithDetails(int productDetailId);

    }
}
