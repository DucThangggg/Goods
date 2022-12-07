using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DTO;
using Goods.Goods_DTO.Good_Show;

namespace Goods.Goods_BLL.Service.Interface
{
    public interface IUserBLL
    {
        // Post User
        Task<User_SignUp> SignUpAnAccount_Map(User_SignUp user_Post);
        // SignIn
        Task<User_Show> SignInAnAnccount(User_DTO user_Post);
        Task<User_Show> RefreshToken(string refreshToken);
        UserRefresh_Show GetRefreshToken();
        string SetToken(User_Entities user);
    }
}
