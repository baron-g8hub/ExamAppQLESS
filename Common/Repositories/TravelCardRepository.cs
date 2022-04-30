using Common.Contracts;
using Common.DataAccess;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Common.Repositories
{
    public class TravelCardRepository : RepositoryBase<TravelCard>, ITravelCardRepository
    {
        public TravelCardRepository(ApplicationDbContext context) : base(context)
        {

        }

        public virtual IQueryable<TravelCard> GetAllTravelCards()
        {
            return _context.Set<TravelCard>();
        }
        public virtual async Task<ICollection<TravelCard>> GetTravelCardsAsync()
        {
            try
            {
                return await _context.Set<TravelCard>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public virtual TravelCard GetTravelCard(int id)
        {
            if (_context != null)
            {
                if (_context.TravelCards != null)
                {
                    var user = _context.TravelCards.Find(id);
                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            return new TravelCard();
        }
        public async Task<TravelCard> GetTravelCardAsync(int id)
        {
            var result = await _context.TravelCards.FindAsync(id);
            if (result != null)
            {
                return result;
            }
            return result!;
        }

        public virtual void AddTravelCard(TravelCard travelCard)
        {
            _context.TravelCards.Add(travelCard);
        }

        public virtual async Task AddTravelCardAsync(TravelCard travelCard)
        {
            await _context.TravelCards.AddAsync(travelCard);
        }

        public virtual TravelCard UpdateTravelCard(TravelCard travelCard)
        {
            _context.Update(travelCard);
            return travelCard;
        }

        public virtual void DeleteTravelCard(int id)
        {
            if (_context != null)
            {
                if (_context.TravelCards != null)
                {
                    TravelCard? travelCard = _context.TravelCards.Find(id);
                    if (travelCard != null)
                    {
                        _context.TravelCards.Remove(travelCard);
                    }
                }
            }
        }
    }
}
