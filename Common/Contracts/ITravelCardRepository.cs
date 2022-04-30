using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface ITravelCardRepository : IRepositoryBase<TravelCard>
    {
        IQueryable<TravelCard> GetAllTravelCards();
        Task<ICollection<TravelCard>> GetTravelCardsAsync();

        TravelCard GetTravelCard(int id);
        Task<TravelCard> GetTravelCardAsync(int id);

        void AddTravelCard(TravelCard travelCard);
        Task AddTravelCardAsync(TravelCard travelCard);

        TravelCard UpdateTravelCard(TravelCard travelCard);
    

        void DeleteTravelCard(int id);
    }
}
