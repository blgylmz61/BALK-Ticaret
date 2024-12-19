using BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface ICardService
    {
        Task<bool> CheckCard(string cardNumber); //Card codu kontrolu
        Task<CardDto> GetCardId(int cardId); //Tek card getir
        Task CreateCard(CardDto cardDto); //card oluştur
        Task<List<CardDto>> GetAllCard(); //bütün card getir
        Task DeleteCard(int cardId); //ürün sil
        Task UpdateCard(CardDto cardDto); // Güncelle
        Task<List<CardDto>> Search(string searchedTerm); //Arama 
        Task<IEnumerable<CardDto>> GetCardByConditionAsync(Expression<Func<CardDto, bool>> predicate);

    }
}
