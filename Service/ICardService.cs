using Model;

namespace Service
{
    public interface ICardService
    {
        Task<IEnumerable<Card>> GetCardsAsync();
        Task<Card> CreateCardAsync(Card card);
        Task<Card> GetCardByIdAsync(Guid id);
        Task<Card> UpdateCardAsync(Guid id, Card card);
        Task<IEnumerable<Card>> DeleteCardAsync(Guid id);
    }
}
