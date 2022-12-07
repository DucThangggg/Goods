using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface IOrdersBLL
    {
        Task<IEnumerable<Orders_Show>> GetOrders_Map();
        Task<Orders_DTO> PostOrdes_Map(Orders_DTO oders_Post, string userName);

    }
}
