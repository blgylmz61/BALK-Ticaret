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
    public class CardService : ICardService
    {
        private readonly IRepository<Card> _cardRepository;
        private readonly IMapper _mapper;

        public CardService(IRepository<Card> cardRepository,IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }
        public async Task<string> CapitalizeFirstLetterOfEachWord(string text)
        {
            return await Task.Run(() =>
            {
                var textTrim = text.TrimStart();
                var words = textTrim.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                    {
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
                    }
                }
                return string.Join(" ", words);
            });
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
