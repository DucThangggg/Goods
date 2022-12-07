using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface ICartsInfoRepository
    {
        // Get Al
        Task<IEnumerable<Carts_Entities>> GetCarts_Entities();
        // Post
        Task AddCarts(Carts_Entities carts_Entities, Items_Entities items_Entities, User_Entities user_Entities);
        Task<Carts_Entities> FindCartsWithID_Entities(int IDCarts);

    }
}
