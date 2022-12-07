using AutoMapper;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Implement
{
    public class OrderDetailsBLL : IOrderDetailsBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        // Hàm khởi tạo
        public OrderDetailsBLL(IGoodsUnitOfWork goods, IMapper mapper)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<OrderDetails_DTO>> GetOrderDetails_Map()
        {
            var orderDetails_Entities = await _goods.orderDetailsInfoRepository.GetOrderDetails_Entities();
            return _mapper.Map<IEnumerable<OrderDetails_DTO>>(orderDetails_Entities);
        }
        public async Task<bool> PostOrderDetails_Map(int CartsId, int OrdersId)
        {
            var order = await _goods.ordersInfoRepository.FindIDOrders_Entities(OrdersId);

            var cart = await _goods.cartsInfoRepository.FindCartsWithID_Entities(CartsId);

            var orderDetails_Entities = new OrderDetails_Entities();

            orderDetails_Entities.Amount = cart.Amount;
            orderDetails_Entities.ProductAllPrice = cart.ProductAllPrice;
            // Add all items_Entities để Mapper
            orderDetails_Entities.items_Entities = cart.items_Entities;
            orderDetails_Entities.ProductId = cart.ProductId;
            //// Lấy thông tin từ orders
            //orderDetails_Entities.orders_Entities = order;
            //orderDetails_Entities.OrdersId = order.OrdersId;
            await _goods.orderDetailsInfoRepository.AddOrderDetails(orderDetails_Entities, order);
            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return true;
        }
    }
}
