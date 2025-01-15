using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public interface ITireReturnedItemsService
    {
        Task<IEnumerable<TireReturnedItems>> GetAllTireReturnedItems();
        Task<TireReturnedItems> GetTireReturnedItemById(int id);
        Task AddTireReturnedItem(TireReturnedItems tireReturnedItem);
        Task UpdateTireReturnedItem(TireReturnedItems tireReturnedItem);
        Task DeleteTireReturnedItem(int id);
    }
}