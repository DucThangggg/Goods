using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.AutoMap
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            CreateMap<Items_Entities, Items_DTO>();
            CreateMap<Items_DTO, Items_Entities>();
        }
    }
}
