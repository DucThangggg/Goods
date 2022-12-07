using AutoMapper;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;
using Goods.Goods_DTO.Good_Show;

namespace Goods.Goods_BLL.AutoMap
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User_Entities, User_DTO>();
            CreateMap<User_DTO, User_Entities>();
            CreateMap<User_Entities, User_SignUp>();
            CreateMap<User_SignUp, User_Entities>();
        }
    }
}
