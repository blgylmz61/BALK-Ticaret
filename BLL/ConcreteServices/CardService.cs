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
    public class CardService : ICardService
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly IMapper _mapper;

        public CardService(IRepository<Card> cardRepository,IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
       

        public async Task<bool> CheckCard(string cardNumber)
        {
            var cards = await _cardRepository.GetAllAsync();
            if (cards != null)
            {
                var sameCardNumber = cards.Any(x => x.CardNumber == cardNumber);
                return sameCardNumber;
            }
            return false;
        }

        public async Task CreateCard(CardDto cardDto)
        {
           await _cardRepository.AddAsync(_mapper.Map<Card>(cardDto));
        }

        public async Task DeleteCard(int cardId)
        {
            await _cardRepository.DeleteAsync(cardId);
        }

        public async Task<List<CardDto>> GetAllCard()
        {
           var cards=await _cardRepository.GetAllAsync();
            foreach (var card in cards) { 
            card.CardHolder=StringHelper.CapitalizeFirstLetterOfEachWord(card.CardHolder);
            }
            return _mapper.Map<List<CardDto>>(cards);
        }

        public async Task<IEnumerable<CardDto>> GetCardByConditionAsync(Expression<Func<CardDto, bool>> predicate)
        {
            var cardPredicate = _mapper.Map<Expression<Func<Card, bool>>>(predicate);
            var cards = await _cardRepository.FindAsync(cardPredicate);
            return _mapper.Map<IEnumerable<CardDto>>(cards);
          
        }

        public async Task<CardDto> GetCardId(int cardId)
        {
           var card=await _cardRepository.GetByIdAsync(cardId);
            return (_mapper.Map<CardDto>(card));
        }

        public Task<List<CardDto>> Search(string searchedTerm)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCard(CardDto cardDto)
        {
            throw new NotImplementedException();
        }
    }
}
