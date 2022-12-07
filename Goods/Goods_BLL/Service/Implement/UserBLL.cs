using AutoMapper;
using Azure;
using Azure.Core;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Implement;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;
using Goods.Goods_DTO.Good_Show;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Goods.Goods_BLL.Service.Implement
{
    public class UserBLL : IUserBLL
    {
        public IGoodsUnitOfWork _goods;
        public IMapper _mapper;
        public IConfiguration _configuration;
        // Hàm khởi tạo
        public UserBLL(IGoodsUnitOfWork goods, IMapper mapper, IConfiguration configuration)
        {
            _goods = goods ??
                throw new ArgumentNullException(nameof(goods));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }
        // Đăng ký tài khoản
        public async Task<User_SignUp> SignUpAnAccount_Map(User_SignUp user_Post)
        {
            var _findUser = await _goods.userInfoRepository.FindUserName_Entities(user_Post.UserName);
            if (_findUser != null)
            {
                return null;
            }
            var userPost = _mapper.Map<User_Entities>(user_Post);
            await _goods.userInfoRepository.SignUpAnAccount(userPost);
            // Lưu giá trị vào Database
            await _goods.SaveChanges();
            return _mapper.Map<User_SignUp>(userPost);
        }
        public async Task<User_Show> SignInAnAnccount(User_DTO user_Post)
        {
            // step 1: Tìm theo UserName and Password
            var _findUser = await _goods.userInfoRepository.FindUser_Entities(user_Post.UserName, user_Post.Password);
            if (_findUser == null)
            {
                return null;
            }
            var Token = SetToken(_findUser);
            
            var refreshToken = GetRefreshToken();

            // Lưu giá trị vào Database
            _findUser.RefreshToken = refreshToken.RefreshToken;
            _findUser.TokenCreated = refreshToken.TokenCreated;
            _findUser.TokenExpires = refreshToken.TokenExpires;
            await _goods.SaveChanges();

            var userShow = new User_Show();
            userShow.AccessToken = Token;
            userShow.RefreshToken = refreshToken.RefreshToken;
            userShow.TokenCreated = refreshToken.TokenCreated;
            userShow.TokenExpires = refreshToken.TokenExpires;

            return userShow;
        }
        public async Task<User_Show> RefreshToken(string refreshToken)
        {
            // Từ token tìm ra User
            var user = await _goods.userInfoRepository.FindUserByToken_Entities(refreshToken);

            // Tạo ra một Refresh mới radom sau đó lưu xuống CSDL
            var newRefreshToken = GetRefreshToken();
            // Lưu giá trị vào Database (là một UserRefresh_Show)
            user.RefreshToken = newRefreshToken.RefreshToken;
            user.TokenCreated = newRefreshToken.TokenCreated;
            user.TokenExpires = newRefreshToken.TokenExpires;
            await _goods.SaveChanges();
            var accessToken = SetToken(user);
            // Khai báo và gán để trả về một User_Show
            var userShow = new User_Show();
            userShow.RefreshToken = newRefreshToken.RefreshToken;
            userShow.AccessToken = accessToken;
            userShow.TokenCreated = newRefreshToken.TokenCreated;
            userShow.TokenExpires = newRefreshToken.TokenExpires;

            return userShow;
        }
        // Set Token
        public string SetToken(User_Entities user)
        {
            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForkey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // The claims that, UserName phải là sub thì mới lấy được tên từ User sang các bảng khóa ngoại
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("sub", user.UserName));
            claimsForToken.Add(new Claim("password", user.Password));
            claimsForToken.Add(new Claim("role", user.Role));
            claimsForToken.Add(new Claim("firstname", user.FirstName));
            claimsForToken.Add(new Claim("lastname", user.LastName));
            claimsForToken.Add(new Claim("phone", user.Phone.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().
                WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }
        // Get Refresh
        public UserRefresh_Show GetRefreshToken()
        {
            var refreshToken = new UserRefresh_Show
            {
                RefreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                TokenExpires = DateTime.Now.AddDays(7),
                TokenCreated = DateTime.Now
            };
            return refreshToken;
        }
    }
}
