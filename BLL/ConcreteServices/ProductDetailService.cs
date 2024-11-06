using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IMapper _mapper;

        public ProductDetailService(IRepository<ProductDetail> productDetailRepository, IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _mapper = mapper;
        }
        public async Task CreateProductDetail(ProductDetailDto productDetailDto)
        {
            await _productDetailRepository.AddAsync(_mapper.Map<ProductDetail>(productDetailDto));
        }

        public async Task DeleteProductDetail(int productDetailId)
        {
            await _productDetailRepository.DeleteAsync(productDetailId);
        }

        public async Task<List<ProductDetailDto>> GetProductDetailAll()
        {
            var productDetails = await _productDetailRepository.GetAllAsync();
            return _mapper.Map<List<ProductDetailDto>>(productDetails);
        }

        public async Task<IEnumerable<ProductDetailDto>> GetProductDetailByConditionAsync(Expression<Func<ProductDetailDto, bool>> predicate)
        {
            var productDetailPredicate = _mapper.Map<Expression<Func<ProductDetail, bool>>>(predicate);
            var porductDetails = await _productDetailRepository.FindAsync(productDetailPredicate);
            return _mapper.Map<IEnumerable<ProductDetailDto>>(porductDetails);
        }

        public async Task<ProductDetailDto> GetProductDetailById(int productDetailId)
        {
            var productDetail = await _productDetailRepository.GetByIdAsync(productDetailId);
            return _mapper.Map<ProductDetailDto>(productDetail);
        }


        public Task UpdateProductDetail(ProductDetailDto productDetailDto)
        {
            throw new NotImplementedException();
        }
    }
}
