using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Goods.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class OrdesController : ControllerBase
    {
        public IOrdersBLL _ordersBll;
        // Hàm khởi tạo
        public OrdesController(IOrdersBLL ordersBll)
        {
            _ordersBll = ordersBll ??
                throw new ArgumentNullException(nameof(ordersBll));
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Orders_Show>>> GetOrders_Map()
        {
            return Ok(await _ordersBll.GetOrders_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Orders_DTO>>> PostOrdes_Map(Orders_DTO oders_Post)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _ordersBll.PostOrdes_Map(oders_Post, userName));
        }
    }
}
