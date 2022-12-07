using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.AutoMap
{
    public class OrderDetailsProfile : Profile
    {
        public OrderDetailsProfile()
        {
            CreateMap<OrderDetails_Entities, OrderDetails_DTO>().ForMember(productName => productName.ProductName,
                           options => options.MapFrom(source => source.items_Entities.ProductName));
            CreateMap<OrderDetails_DTO, OrderDetails_Entities>();
        }
    }
}
