using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public interface ITireReleasedItemsService
    {
        Task<IEnumerable<TireReleasedItems>> GetAllTireReleasedItems();
        Task<TireReleasedItems> GetTireReleasedItemById(int id);
        Task AddTireReleasedItem(TireReleasedItems tireReleasedItem);
        Task UpdateTireReleasedItem(TireReleasedItems tireReleasedItem);
        Task DeleteTireReleasedItem(int id);
    }
}