using Goods.Goods_DAL.Repository.Implement;
using Goods.Goods_DAL.Repository.Interface;

namespace Goods.Goods_DAL.UnitOfWork.Interface
{
    public interface IGoodsUnitOfWork
    {
        // Gọi UserInfoRepository qua phương thức
        UserInfoRepository userInfoRepository { get; }
        // Gọi ItemsInfoRepository qua phương thức
        ItemsInfoRepository itemsInfoRepository { get; }
        // Gọi CartsInfoRepository qua phương thức
        CartsInfoRepository cartsInfoRepository { get; }
        // Gọi ReviewsInfoRepository qua phương thức
        ReviewsInfoRepository reviewsInfoRepository { get; }
        // Gọi OdersInfoRepository qua phương thức
        OrdersInfoRepository ordersInfoRepository { get; }
        // Gọi OderDetailsInfoRepository qua phương thức
        OrderDetailsInfoRepository orderDetailsInfoRepository { get; }
        // Lưu thay đổi
        Task SaveChanges();
    }
}
