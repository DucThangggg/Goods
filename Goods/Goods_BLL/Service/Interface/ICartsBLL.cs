using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface ICartsBLL
    {
        // Get All
        Task<IEnumerable<Carts_Show>> GetCarts_Map();
        // Post Product
        Task<Carts_DTO> PostCarst_Map(Carts_DTO Carts_Post, string userName);
    }
}
