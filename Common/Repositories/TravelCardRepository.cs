using Common.Contracts;
using Common.DataAccess;
using Common.Models;

namespace Common.Repositories
{
    public class TravelCardRepository : ITravelCardRepository
    {
        private readonly ApplicationDbContext _context;

        public TravelCardRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public ICollection<TravelCard> GetTravelCards()
        {
            if (_context != null)
            {
                if (_context.TravelCards != null)
                {
                    return _context.TravelCards.ToList();
                }
            }
            return new List<TravelCard>();
        }


        public TravelCard GetTravelCard(int id)
        {
            if (_context != null)
            {
                if (_context.TravelCards != null)
                {
                    var user = _context.TravelCards.FirstOrDefault(x => x.TravelCardID == id);
                    if (user != null)
                    {
                        return user;
                    }
                }
            }
            return new TravelCard();
        }

        public void AddTravelCard(TravelCard travelCard)
        {
            _context.Add(travelCard);
            _context.SaveChanges();
        }

        public TravelCard UpdateTravelCard(TravelCard travelCard)
        {
            _context.Update(travelCard);
            _context.SaveChanges();
            return travelCard;
        }

        public void DeleteTravelCard(int id)
        {
            if (_context != null)
            {
                if (_context.TravelCards != null)
                {
                    TravelCard? travelCard = _context.TravelCards.Find(id);
                    if (travelCard != null)
                    {
                        _context.TravelCards.Remove(travelCard);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
