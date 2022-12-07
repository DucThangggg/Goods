using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.AutoMap
{
    public class CartsProfile : Profile
    {
        public CartsProfile()
        {
            CreateMap<Carts_Entities, Carts_DTO>().ForMember(productName => productName.ProductName,
                           options => options.MapFrom(source => source.items_Entities.ProductName)); // Hiển thị Destination từ Map Entiites vs List;
            CreateMap<Carts_DTO, Carts_Entities>();
            CreateMap<Carts_Entities, Carts_Show>().ForMember(productName => productName.ProductName,
                           options => options.MapFrom(source => source.items_Entities.ProductName)).ForMember(userName => userName.UserName,
                           options => options.MapFrom(source => source.user_Entities.UserName)); // Hiển thị Destination từ Map Entiites vs List;
        }
    }
}
