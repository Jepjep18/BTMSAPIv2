using BTMSAPI.Models;
using System.Collections.Generic;

namespace BTMSAPI.Services
{
    public interface ITireItemService
    {
        IEnumerable<TireItem> GetAllTireItems();
        TireItem GetTireItemById(int id);
        void CreateTireItem(TireItem newTireItem);
        void UpdateTireItem(TireItem updatedTireItem);
        void DeleteTireItem(int id);
    }
}