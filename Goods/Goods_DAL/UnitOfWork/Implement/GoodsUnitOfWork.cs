using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Repository.Implement;
using Goods.Goods_DAL.Repository.Interface;
using Goods.Goods_DAL.UnitOfWork.Interface;

namespace Goods.Goods_DAL.UnitOfWork.Implement
{
    public class GoodsUnitOfWork : IGoodsUnitOfWork, IDisposable
    {
        // _context giá trị của client nhập vào
        private readonly MyDbContext _context;
        // Khai báo trường cho object UserInfoRepository
        private UserInfoRepository _userInfoRepository;
        // Khai báo trường cho object ItemsInfoRepository
        private ItemsInfoRepository _itemsInfoRepository;
        // Khai báo trường cho object CartsInfoRepository
        private CartsInfoRepository _cartsInfoRepository;
        // Khai báo trường cho object ReviewsInfoRepository
        private ReviewsInfoRepository _reviewsInfoRepository;
        // Khai báo trường cho object OrdersInfoRepository
        private OrdersInfoRepository _ordersInfoRepository;
        // Khai báo trường cho object OrdersDetailsInfoRepository
        private OrderDetailsInfoRepository _orderDetailsInfoRepository;
        // Hàm khởi tạo UserInfoRepository
        public UserInfoRepository userInfoRepository
        {
            get
            {
                _userInfoRepository = new UserInfoRepository(_context);
                return _userInfoRepository;
            }
        }
        // Hàm khởi tạo ItemsInfoRepository
        public ItemsInfoRepository itemsInfoRepository
        {
            get
            {
                _itemsInfoRepository = new ItemsInfoRepository(_context);
                return _itemsInfoRepository;
            }
        }
        // Hàm khởi tạo CartsInfoRepository
        public CartsInfoRepository cartsInfoRepository
        {
            get
            {
                _cartsInfoRepository = new CartsInfoRepository(_context);
                return _cartsInfoRepository;
            }
        }
        // Hàm khởi tạo ReviewsInfoRepository
        public ReviewsInfoRepository reviewsInfoRepository
        {
            get
            {
                _reviewsInfoRepository = new ReviewsInfoRepository(_context);
                return _reviewsInfoRepository;
            }
        }
        // Hàm khởi tạo OrdersInfoRepository
        public OrdersInfoRepository ordersInfoRepository
        {
            get
            {
                _ordersInfoRepository = new OrdersInfoRepository(_context);
                return _ordersInfoRepository;
            }
        }
        // Hàm khởi tạo OrdersInfoRepository
        public OrderDetailsInfoRepository orderDetailsInfoRepository
        {
            get
            {
                _orderDetailsInfoRepository = new OrderDetailsInfoRepository(_context);
                return _orderDetailsInfoRepository;
            }
        }
        public GoodsUnitOfWork(MyDbContext context)
        {
            _context = context;
        }
        //Save vào CSDL
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Dispose");
            //Console.ResetColor();
        }
    }
}
