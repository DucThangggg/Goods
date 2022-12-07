using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.AutoMap
{
    public class OrdersProfile : Profile
    {
        public OrdersProfile()
        {
            CreateMap<Orders_Entities, Orders_DTO>();
            CreateMap<Orders_DTO, Orders_Entities>();
            CreateMap<Orders_DTO, Orders_Entities>();
            CreateMap<Orders_Entities, Orders_Show>().ForMember(userName => userName.UserName,
                           options => options.MapFrom(source => source.user_Entities.UserName)); // Hiển thị Destination từ Map Entiites vs List;
        }
    }
}
