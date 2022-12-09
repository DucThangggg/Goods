using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DAL.Goods_Entities;
using Goods.Goods_DAL.UnitOfWork.Interface;
using Goods.Goods_DTO;
using Goods.Goods_DTO.Good_Show;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using Firebase.Auth;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;

namespace Goods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserBLL _userBll;
        public const string API_KEY = "AIzaSyAtgy4ii-sG-ab1hLyyFFW_2HJ51JesKN0";
        // Hàm khởi tạo
        public UserController(IUserBLL userBll)
        {
            _userBll = userBll ??
                throw new ArgumentNullException(nameof(userBll));
        }
        [HttpPost("SignUpAccount")]
        public async Task<ActionResult<IEnumerable<User_SignUp>>> SignUpAnAccount_Map(User_SignUp user_Post)
        {
            return Ok(await _userBll.SignUpAnAccount_Map(user_Post));
        }
        [HttpPost("SignInAccount")]
        public async Task<ActionResult<string>> SignInAnAnccount(User_DTO user_Post)
        {
            var userShow = await _userBll.SignInAnAnccount(user_Post);
            // set refreshToken
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = userShow.TokenExpires
            };
            Response.Cookies.Append("refreshToken", userShow.RefreshToken, cookieOptions);

            return Ok(userShow.AccessToken);
        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult<string>> RefreshToken()
        {
            // Lấy refresh token từ cookies
            var refreshToken = Request.Cookies["refreshToken"];
            // Từ token tìm ra User
            var user = await _userBll.RefreshToken(refreshToken);
            // Nếu có không có user thì trả về Invalid
            if (user == null)
            {
                return Unauthorized("Invalid Refresh Token");
            }    
            else if(user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token Expirred");
            }
            // Tạo ra một Refresh mới radom sau đó lưu xuống CSDL

            // Lưu vào Cookie (Bộ nhớ đệm )
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = user.TokenExpires
            };
            Response.Cookies.Append("refreshToken", user.RefreshToken, cookieOptions);
            // Tạo ra AccessToken từ RefreshToken trong database
            
            return Ok(user.AccessToken);
        }
        [HttpPost("SignInByFirebaseEmail")]
        public async Task<ActionResult<string>> SignInFirebaseEmail(string email)
        {
            FirebaseAuthProvider firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            //FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync("singletonsean@gmail.com", "test123", "SingletonSean");
            FirebaseAuthLink firebaseAuthLink = await firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, "test123");

            return firebaseAuthLink.FirebaseToken;
        }
        [Authorize]
        [HttpGet("SignInWithGoogle")]
        public async Task<ActionResult<string>> SignInGoogle()
        {
            // Đặt tên google cùng với khai báo Authentication bên Programs
            var accessToken = await HttpContext.GetTokenAsync("google", "access_token");
            return accessToken;
        }
    }
}
