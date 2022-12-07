using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class ReviewsInfoRepository : IReviewsInfoRepository
    {
        private readonly MyDbContext _context;
        public ReviewsInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Add reviews
        public async Task AddReviews(Reviews_Entities reviews_Entities, Items_Entities items_Entities, User_Entities user_Entities)
        {
            // add items vào carts
            items_Entities.ListReviews.Add(reviews_Entities);
            // Tăng số lượng review cho sản phẩm
            items_Entities.NumberReview = items_Entities.ListReviews.Count;
            // add user vào reviews
            user_Entities.ListReviews.Add(reviews_Entities);
        }
        // get all review
        public async Task<IEnumerable<Reviews_Entities>> GetReviews_Entities()
        {
            // Get Carts có thêm thông tin ProductName từ Items
            return await _context.reviews_Entities.Include(x => x.items_Entities).Include(x => x.user_Entities).ToListAsync();
        }
    }
}
