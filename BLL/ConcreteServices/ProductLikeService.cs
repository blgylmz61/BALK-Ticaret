using AutoMapper;
using BLL.AbstractServices;
using BLL.Dtos;
using DAL.AbstractRepository;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ConcreteServices
{
    public class ProductLikeService : IProductLikeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductLike> _productLikeRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<User> _userRepository;

        public ProductLikeService(IMapper mapper,IRepository<ProductLike> productLikeRepository,IRepository<Product> productRepository,IRepository<User> userRepository)
        {
            _mapper = mapper;
            _productLikeRepository = productLikeRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }
        public async Task CreateLike(ProductLikeDto productLikeDto)
        {
            await _productLikeRepository.AddAsync(_mapper.Map<ProductLike>(productLikeDto));
        }

        public async Task DeleteLike(int productLikeId)
        {
            await _productLikeRepository.DeleteAsync(productLikeId);
        }

        public async Task<List<ProductLikeDto>> GetAllLike()
        {
            var productLikes = await _productLikeRepository.GetAllAsync();
            return (_mapper.Map<List<ProductLikeDto>>(productLikes));
        }

        public async Task<ProductLikeDto> GetLikeById(int productLikeId)
        {
            var productLike = await _productLikeRepository.GetByIdAsync(productLikeId);
            return (_mapper.Map<ProductLikeDto>(productLike));
        }

        public async Task<ProductLikeDto> GetLikeByProductId(int productId)
        {
            var productLikes=(await _productLikeRepository.FindAsync(x=>x.ProductId==productId)).ToList();

            return (_mapper.Map<ProductLikeDto>(productLikes));

        }

        public async Task<ProductLikeDto> GetLikeByUserId(int userId)
        {
            var userLikes = await _productLikeRepository.FindAsync(x => x.UserId == userId);
            return (_mapper.Map<ProductLikeDto>(userLikes));
        }

        public async Task HasLikeByUserOnProduct(int productId, int userId)
        {
            var likeProduct = await _productRepository.GetByIdAsync(productId); //beğenilen product al
            var likeUser = await _userRepository.GetByIdAsync(userId); //beğenen kullanıcı al
            var productLikes = await _productLikeRepository.GetAllAsync(); // bütm likeları al
            var productLiked = productLikes.FirstOrDefault(x => x.UserId == userId && x.ProductId == productId); // kullanıcı bu ürünü beğendi mi?

            //like verilerini ekle
            var like = _mapper.Map<ProductLikeDto>(new ProductLike());
            like.UserId = userId;
            like.ProductId = productId;

            //like.Product = _mapper.Map<ProductDto>(likeProduct);
            //like.User = _mapper.Map<UserDto>(likeUser);


            if (productLiked == null ) // daha önce beğenmediyse
            {
                //like veritabanına ekle
                await _productLikeRepository.AddAsync(_mapper.Map<ProductLike>(like));
                likeProduct.LikeCount++;
                
            }
            else
            {
                await _productLikeRepository.DeleteAsync(productLiked.Id);
                likeProduct.LikeCount--;
                
            }
            await _productRepository.UpdateAsync(likeProduct);
           
        }

      
    }
}
