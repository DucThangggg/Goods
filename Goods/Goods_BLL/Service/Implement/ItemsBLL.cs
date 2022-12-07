using AutoMapper;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.Service.Implement
{
    public class ItemsBLL : IItemsBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        // Hàm khởi tạo
        public ItemsBLL(IGoodsUnitOfWork goods, IMapper mapper)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        // Detele
        public async Task<bool> DeleteItemsID(int IDProduct)
        {
            // Tìm theo ID
            var _deleteItems = await _goods.itemsInfoRepository.FindIDItems_Entities(IDProduct);
            if (_deleteItems == null)
            {
                return false;
            }
            await _goods.itemsInfoRepository.DeleteItemsID(IDProduct);
            await _goods.SaveChanges();
            return true;
        }
        // Get All
        public async Task<IEnumerable<Items_DTO>> GetItems_Map()
        {
            // Gọi hàm thông qua Unit và Object ItemsInfoRepository khai báo ở IGoodsUnitOfWork
            var items_Entities = await _goods.itemsInfoRepository.GetItems_Entities();
            return _mapper.Map<IEnumerable<Items_DTO>>(items_Entities);
        }
        // Post
        public async Task<Items_DTO> PostItems_Map(Items_DTO items_Post)
        {
            var itemsPost = _mapper.Map<Items_Entities>(items_Post);
            await _goods.itemsInfoRepository.AddItems(itemsPost);
            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return _mapper.Map<Items_DTO>(itemsPost);
        }
    }
}
