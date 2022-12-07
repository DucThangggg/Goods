using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface IItemsBLL
    {
        Task<IEnumerable<Items_DTO>> GetItems_Map();
        Task<Items_DTO> PostItems_Map(Items_DTO items_Post);
        Task<bool> DeleteItemsID(int IDProduct);
    }
}
