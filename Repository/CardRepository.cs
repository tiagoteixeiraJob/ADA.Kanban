using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _context;

        public CardRepository(CardContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> Get()
        {
            var cards = await _context.Cards.AsNoTracking().ToListAsync();
            return cards;
        }

        public async Task<Card> Create(Card card)
        {
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> GetById(Guid id)
        {
            var card = await _context.Cards.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            return card;
        }

        public async Task<Card> Update(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<bool> Delete(Card card)
        {
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
