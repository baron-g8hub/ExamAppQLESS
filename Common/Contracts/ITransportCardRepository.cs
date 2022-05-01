using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface ITransportCardRepository : IRepositoryBase<TransportCard>
    {
        IQueryable<TransportCard> GetAllTransportCards();
        Task<ICollection<TransportCard>> GetTransportCardsAsync();

        TransportCard GetTransportCardById(int id);
        Task<TransportCard> GetTransportCardByIdAsync(int id);

        void AddTransportCard(TransportCard travelCard);
        Task AddTransportCardAsync(TransportCard travelCard);

        TransportCard UpdateTransportCard(TransportCard travelCard);
    

        void DeleteTransportCard(int id);
    }
}
