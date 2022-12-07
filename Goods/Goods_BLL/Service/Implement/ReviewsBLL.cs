using AutoMapper;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Implement
{
    public class ReviewsBLL : IReviewsBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        // Hàm khởi tạo
        public ReviewsBLL(IGoodsUnitOfWork goods, IMapper mapper)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<Reviews_Show>> GetReviews_Map()
        {
            var reviews_Entities = await _goods.reviewsInfoRepository.GetReviews_Entities();
            return _mapper.Map<IEnumerable<Reviews_Show>>(reviews_Entities);
        }
        public async Task<Reviews_DTO> PostReviews_Map(Reviews_DTO Review_Post, string userName)
        {
            // ticket_Post là Object Ticket_DTO được thêm vào, chấm Destination là gọi biến trong Object Booking đó
            var itemsEntities = await _goods.itemsInfoRepository.FindNameItems_Entities(Review_Post.ProductName);
            // Tìm ra User từ UserName
            var userEntities = await _goods.userInfoRepository.FindUserName_Entities(userName);
            var reviewPost = _mapper.Map<Reviews_Entities>(Review_Post);
            await _goods.reviewsInfoRepository.AddReviews(reviewPost, itemsEntities, userEntities);
            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return _mapper.Map<Reviews_DTO>(reviewPost);
        }
    }
}
