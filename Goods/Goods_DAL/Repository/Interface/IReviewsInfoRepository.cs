using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface IReviewsInfoRepository
    {
        Task AddReviews(Reviews_Entities reviews_Entities, Items_Entities items_Entities, User_Entities user_Entities);
        Task<IEnumerable<Reviews_Entities>> GetReviews_Entities();
    }
}
