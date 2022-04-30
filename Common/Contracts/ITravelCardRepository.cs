using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface ITravelCardRepository
    {
        ICollection<TravelCard> GetTravelCards();
        TravelCard GetTravelCard(int id);
        void AddTravelCard(TravelCard travelCard);
        TravelCard UpdateTravelCard(TravelCard travelCard);
        void DeleteTravelCard(int id);
    }
}
