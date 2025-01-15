using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public interface ITireDisposedItemsService
    {
        Task<IEnumerable<TireDisposedItems>> GetAllTireDisposedItems();
        Task<TireDisposedItems> GetTireDisposedItemById(int id);
        Task AddTireDisposedItem(TireDisposedItems tireDisposedItem);
        Task UpdateTireDisposedItem(TireDisposedItems tireDisposedItem);
        Task DeleteTireDisposedItem(int id);
    }
}