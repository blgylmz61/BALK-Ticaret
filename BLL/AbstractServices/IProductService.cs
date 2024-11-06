using BLL.Dtos;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IProductService
    {
        Task<bool> CheckProduct(string productcode); //ürün codu kontrolu
        Task<ProductDto> GetProductId(int productId); //Tek ürün getir
        Task CreateProduct(ProductDto productDto); //ürün oluştur
        Task<List<ProductDto>> GetAllProducts(); //bütün ürünleri getir
        Task DeleteProduct(int productId); //ürün sil
        Task UpdateProduct(ProductDto productDto); //ürün Güncelle
        Task<List<ProductDto>> Search(string searchedTerm); //Arama 
        Task<ProductDto> GetProductWithDetail(int productDetailId);


    }
}
