using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface IOrdersInfoRepository
    {
        Task AddOrders(Orders_Entities orders_Entities, User_Entities user_Entities);
        Task<IEnumerable<Orders_Entities>> GetOrders_Entities();
        Task<Orders_Entities?> FindIDOrders_Entities(int IDOrders);
    }
}
