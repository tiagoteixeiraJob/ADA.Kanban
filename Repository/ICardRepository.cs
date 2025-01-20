using Model;

namespace Repository
{
    public interface ICardRepository
    {
        public Task<IEnumerable<Card>> Get();
        public Task<Card> Create(Card card);
        public Task<Card> GetById(Guid id);
        public Task<Card> Update(Card card);
        public Task<bool> Delete(Card card);
    }
}
