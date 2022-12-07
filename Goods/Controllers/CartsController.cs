using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Goods.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CartsController : ControllerBase
    {
        public ICartsBLL _proBll;
        // Hàm khởi tạo
        public CartsController(ICartsBLL proBll)
        {
            _proBll = proBll ??
                throw new ArgumentNullException(nameof(proBll));
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Carts_Show>>> GetCarts_Map()
        {
            return Ok(await _proBll.GetCarts_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Carts_DTO>>> PostCarst_Map(Carts_DTO Carts_Post)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _proBll.PostCarst_Map(Carts_Post, userName));
        }
    }
}
