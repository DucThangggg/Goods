using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class OrderDetailsInfoRepository : IOrderDetailsInfoRepository
    {
        private readonly MyDbContext _context;
        public OrderDetailsInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<OrderDetails_Entities>> GetOrderDetails_Entities()
        {
            // Get OrderDetails có thêm thông tin ProductName từ Items
            return await _context.orderDetails_Entities.Include(x => x.items_Entities).Include(x => x.orders_Entities).ToListAsync();
        }
        public async Task AddOrderDetails(OrderDetails_Entities orderDetails_Entities, Orders_Entities orders_Entities)
        {
            
            orders_Entities.ListOrderDetails.Add(orderDetails_Entities);
            //foreach (var item in orders_Entities.ListOrderDetails)
            //{
            //    orders_Entities.SumOfPrice = orders_Entities.SumOfPrice + item.ProductAllPrice;
            //}
            orders_Entities.SumOfPrice = orders_Entities.SumOfPrice + orderDetails_Entities.ProductAllPrice;
        }
    }
}
