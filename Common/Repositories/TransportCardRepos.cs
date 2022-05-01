using Common.Contracts;
using Common.DataAccess;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Repositories
{
    public class TransportCardRepos : RepositoryBase<TransportCard>, ITransportCardRepository
    {
        public TransportCardRepos(ApplicationDbContext context) : base(context)
        {

        }

        public virtual IQueryable<TransportCard> GetAllTransportCards()
        {
            return _context.Set<TransportCard>();
        }
        public virtual async Task<ICollection<TransportCard>> GetTransportCardsAsync()
        {
            try
            {
                return await _context.Set<TransportCard>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual TransportCard GetTransportCardById(int id)
        {
            if (_context != null)
            {
                if (_context.TransportCards != null)
                {
                    var user = _context.TransportCards.Find(id);
                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            return new TransportCard();
        }
        public async Task<TransportCard> GetTransportCardByIdAsync(int id)
        {
            var result = await _context.TransportCards.FindAsync(id);
            if (result != null)
            {
                return result;
            }
            return result!;
        }

        public virtual void AddTransportCard(TransportCard travelCard)
        {
            _context.TransportCards.Add(travelCard);
        }

        public virtual async Task AddTransportCardAsync(TransportCard travelCard)
        {
            await _context.TransportCards.AddAsync(travelCard);
        }

        public virtual TransportCard UpdateTransportCard(TransportCard travelCard)
        {
            _context.Update(travelCard);
            return travelCard;
        }

        public virtual void DeleteTransportCard(int id)
        {
            if (_context != null)
            {
                if (_context.TransportCards != null)
                {
                    TransportCard? travelCard = _context.TransportCards.Find(id);
                    if (travelCard != null)
                    {
                        _context.TransportCards.Remove(travelCard);
                    }
                }
            }
        }
    }
}
