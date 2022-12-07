using AutoMapper;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Implement
{
    public class CartsBLL : ICartsBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        // Hàm khởi tạo
        public CartsBLL(IGoodsUnitOfWork goods, IMapper mapper)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<Carts_Show>> GetCarts_Map()
        {
            var carts_Entities = await _goods.cartsInfoRepository.GetCarts_Entities();
            return _mapper.Map<IEnumerable<Carts_Show>>(carts_Entities);
        }
        public async Task<Carts_DTO> PostCarst_Map(Carts_DTO carts_Post, string userName)
        {
            // Tìm ra thông tin Items thông qua ProductName
            var itemsEntities = await _goods.itemsInfoRepository.FindNameItems_Entities(carts_Post.ProductName);
            // Tìm ra User từ UserName
            var UserEntities = await _goods.userInfoRepository.FindUserName_Entities(userName);
            if (carts_Post.Amount > itemsEntities.ProductRemain)
            {
                return null;
            }
            // Số lượng sẽ được Carts lấy đi bên Items
            itemsEntities.ProductRemain = itemsEntities.ProductRemain - carts_Post.Amount;
            // Tính tổng giá một sản phẩm trong một giỏ hàng
            carts_Post.ProductAllPrice = itemsEntities.ProductPrice * carts_Post.Amount;
            var cartsPost = _mapper.Map<Carts_Entities>(carts_Post);
            await _goods.cartsInfoRepository.AddCarts(cartsPost, itemsEntities, UserEntities);
            
            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return _mapper.Map<Carts_DTO>(cartsPost);
        }
    }
}
