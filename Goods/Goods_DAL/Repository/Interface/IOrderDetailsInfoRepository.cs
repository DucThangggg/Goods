using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface IOrderDetailsInfoRepository
    {
        Task<IEnumerable<OrderDetails_Entities>> GetOrderDetails_Entities();
    }
}
