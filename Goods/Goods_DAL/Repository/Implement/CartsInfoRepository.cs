using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class CartsInfoRepository : ICartsInfoRepository
    {
        private readonly MyDbContext _context;
        public CartsInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddCarts(Carts_Entities carts_Entities, Items_Entities items_Entities, User_Entities user_Entities)
        {
            // add items vào carts
            items_Entities.ListCarts.Add(carts_Entities);
            // add user vào carts
            user_Entities.ListCarts.Add(carts_Entities);
        }
        public async Task<IEnumerable<Carts_Entities>> GetCarts_Entities()
        {
            // Get Carts có thêm thông tin ProductName từ Items
            return await _context.carts_Entities.Include(x => x.items_Entities).Include(x => x.user_Entities).ToListAsync();
        }
        // Từ Trip suy ra ID
        public async Task<Carts_Entities> FindCartsWithID_Entities(int IDCarts)
        {
            // Từ ID trả về một Carts_Entities
            var _cartsEntites = await _context.carts_Entities.Include(x => x.items_Entities).Include(x => x.user_Entities).FirstOrDefaultAsync(p => p.CartsId == IDCarts);
            return _cartsEntites;
        }
    }
}
