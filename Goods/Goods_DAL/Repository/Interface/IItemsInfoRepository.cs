using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface IItemsInfoRepository
    {
        // Add items
        Task AddItems(Items_Entities items_Entities);
        // Get All
        Task<IEnumerable<Items_Entities>> GetItems_Entities();
        // Find with ID on Items
        Task<Items_Entities?> FindIDItems_Entities(int IDProduct);
        Task<Items_Entities?> FindNameItems_Entities(string productName);
        // Delete Items
        Task DeleteItemsID(int IDProduct);
    }
}
