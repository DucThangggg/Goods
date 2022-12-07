using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;

namespace Goods.Goods_BLL.AutoMap
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<Reviews_Entities, Reviews_DTO>().ForMember(productName => productName.ProductName,
                           options => options.MapFrom(source => source.items_Entities.ProductName)); // Hiển thị ProductName từ Map Entiites vs List;
            CreateMap<Reviews_DTO, Reviews_Entities>();
            CreateMap<Reviews_DTO, Reviews_Entities>();
            CreateMap<Reviews_Entities, Reviews_Show>().ForMember(productName => productName.ProductName,
                           options => options.MapFrom(source => source.items_Entities.ProductName)).ForMember(userName => userName.UserName,
                           options => options.MapFrom(source => source.user_Entities.UserName));
        }
    }
}
