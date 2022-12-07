using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class OrdersInfoRepository : IOrdersInfoRepository
    {
        private readonly MyDbContext _context;
        public OrdersInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Add Orders
        public async Task AddOrders(Orders_Entities orders_Entities, User_Entities user_Entities)
        {
            _context.orders_Entities.Add(orders_Entities);
            // add user vào carts
            user_Entities.ListOrders.Add(orders_Entities);
        }
        public async Task<IEnumerable<Orders_Entities>> GetOrders_Entities()
        {
            // Get Items ( một List)
            return await _context.orders_Entities.Include(x => x.user_Entities).ToListAsync();
        }
        // Find with ID on Items
        public async Task<Orders_Entities?> FindIDOrders_Entities(int IDOrders)
        {
            var _findOrders = await _context.orders_Entities.Include(x => x.ListOrderDetails).FirstOrDefaultAsync(p => p.OrdersId == IDOrders);
            return _findOrders;
        }
    }
}
