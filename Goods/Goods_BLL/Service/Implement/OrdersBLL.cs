using AutoMapper;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Implement
{
    public class OrdersBLL : IOrdersBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        // Hàm khởi tạo
        public OrdersBLL(IGoodsUnitOfWork goods, IMapper mapper)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<Orders_Show>> GetOrders_Map()
        {
            var orders_Entities = await _goods.ordersInfoRepository.GetOrders_Entities();
            return _mapper.Map<IEnumerable<Orders_Show>>(orders_Entities);
        }
        public async Task<Orders_DTO> PostOrdes_Map(Orders_DTO oders_Post, string userName)
        {
            // Tìm ra User từ UserName
            var userEntities = await _goods.userInfoRepository.FindUserName_Entities(userName);
            var odersPost = _mapper.Map<Orders_Entities>(oders_Post);
            await _goods.ordersInfoRepository.AddOrders(odersPost, userEntities);

            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return _mapper.Map<Orders_DTO>(odersPost);
        }
    }
}
