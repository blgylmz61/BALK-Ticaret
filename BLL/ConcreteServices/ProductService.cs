using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using BLL.Helpers;
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
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> CheckProduct(string productcode)
        {
            if (productcode != null)
            {
                var products = await _productRepository.FindAsync(x => x.ProductCode == productcode);
                if (products != null) { return true; }
            }
            return false;
        }

        public async Task CreateProduct(ProductDto productDto)
        {
            productDto.Name = StringHelper.CapitalizeFirstLetterOfEachWord(productDto.Name);
            await _productRepository.AddAsync(_mapper.Map<Product>(productDto));

        }

        public async Task DeleteProduct(int productId)
        {
            await _productRepository.DeleteAsync(productId);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepository.GetAllAsync();
            return (_mapper.Map<List<ProductDto>>(products));
        }

        public async Task<ProductDto> GetProductId(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            return _mapper.Map<ProductDto>(product);

        }

        public async Task<IEnumerable<ProductDto>> GetProductConditionAsync(Expression<Func<ProductDto, bool>> predicate)
        {
            var productPredicate = _mapper.Map<Expression<Func<Product, bool>>>(predicate);
            var products = await _productRepository.FindAsync(productPredicate);
            return (_mapper.Map<IEnumerable<ProductDto>>(products));
        }

        public Task<List<ProductDto>> Search(string searchedTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetProductWithDetail(int productDetailId)
        {
            var product = await _productRepository.GetWithIncludeAsync(x => x.ProductDetailId == productDetailId, p => p.ProductDetail);
            return (_mapper.Map<ProductDto>(product));
        }
    }
}
