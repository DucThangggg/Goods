using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface IOrderDetailsBLL
    {
        Task<IEnumerable<OrderDetails_DTO>> GetOrderDetails_Map();
        Task<bool> PostOrderDetails_Map(int CartsId, int OrdersId);
    }
}
