using Goods.Goods_DAL.Goods_Entities;

namespace Goods.Goods_DAL.Repository.Interface
{
    public interface IUserInfoRepository
    {
        // Thêm User (Post)
        Task SignUpAnAccount(User_Entities user_Entities);
        // Tìm theo UserName and Password
        Task<User_Entities?> FindUser_Entities(string userName, string password);
        Task<User_Entities?> FindUserName_Entities(string userName);
    }
}
