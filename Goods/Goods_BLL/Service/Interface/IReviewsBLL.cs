using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface IReviewsBLL
    {
        Task<IEnumerable<Reviews_Show>> GetReviews_Map();
        Task<Reviews_DTO> PostReviews_Map(Reviews_DTO Review_Post, string userName);
    }
}
