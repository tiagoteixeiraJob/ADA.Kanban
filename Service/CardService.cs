using Model;
using Repository;

namespace Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<Card>> GetCardsAsync()
        {
            var cards = await _cardRepository.Get();
            return cards;
        }

        public async Task<Card> CreateCardAsync(Card card)
        {
            var cardCreated = await _cardRepository.Create(card);
            return cardCreated;
        }

        public async Task<Card> GetCardByIdAsync(Guid id)
        {
            var card = await _cardRepository.GetById(id);
            return card;
        }

        public async Task<Card> UpdateCardAsync(Guid id, Card card)
        {
            await _cardRepository.Update(card);
            return card;
        }

        public async Task<IEnumerable<Card>> DeleteCardAsync(Guid id)
        {
            var card = await _cardRepository.GetById(id);

            if (card != null)
            {
                var deleted = await _cardRepository.Delete(card);

                if (!deleted)
                    throw new Exception($"Delete card '{id}' error!");

                var cards = await _cardRepository.Get();
                return cards;
            }

            return null;
        }
    }
}
