using Goods.Goods_DAL.DbContexts;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Goods.Goods_DAL.Repository.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly MyDbContext _context;
        public UserInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User_Entities?> FindUser_Entities(string userName, string password)
        {
            var _findUser = await _context.user_Entities.FirstOrDefaultAsync(p => p.UserName == userName && p.Password == password);
            return _findUser;
        }
        public async Task<User_Entities?> FindUserByToken_Entities(string refreshToken)
        {
            var _findUser = await _context.user_Entities.FirstOrDefaultAsync(p => p.RefreshToken == refreshToken);
            return _findUser;
        }
        public async Task SignUpAnAccount(User_Entities user_Entities)
        {
            _context.user_Entities.Add(user_Entities);
        }
        public async Task<User_Entities?> FindUserName_Entities(string userName)
        {
            var _findUserName = await _context.user_Entities.FirstOrDefaultAsync(p => p.UserName == userName);
            return _findUserName;
        }
    }
}
