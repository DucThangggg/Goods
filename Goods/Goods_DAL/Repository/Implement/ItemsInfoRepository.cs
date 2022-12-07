using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class ItemsInfoRepository : IItemsInfoRepository
    {
        private readonly MyDbContext _context;
        public ItemsInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Add Items
        public async Task AddItems(Items_Entities items_Entities)
        {
            _context.items_Entities.Add(items_Entities);
        }
        public async Task<IEnumerable<Items_Entities>> GetItems_Entities()
        {
            // Get Items ( một List)
            return await _context.items_Entities.ToListAsync();
        }
        // Find with ID on Items
        public async Task<Items_Entities?> FindIDItems_Entities(int IDProduct)
        {
            var _findItems = await _context.items_Entities.FirstOrDefaultAsync(p => p.ProductId == IDProduct);
            return _findItems;
        }
        // Find with ID on Items
        public async Task<Items_Entities?> FindNameItems_Entities(string productName)
        {
            var _findItems = await _context.items_Entities.Include(x => x.ListCarts).Include(x => x.ListReviews).FirstOrDefaultAsync(p => p.ProductName == productName);
            return _findItems;
        }
        // Delete Items
        public async Task DeleteItemsID(int IDProduct)
        {
            // Trả về một Object Entities
            var _deleteItems = await _context.items_Entities.FirstOrDefaultAsync(p => p.ProductId == IDProduct);
            if (_deleteItems != null)
            {
                _context.items_Entities.Remove(_deleteItems);
            }
        }
    }
}
