using Goods.Goods_BLL.Service.Implement;
using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Goods.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        public IOrderDetailsBLL _orderDetailsBll;
        // Hàm khởi tạo
        public OrderDetailsController(IOrderDetailsBLL orderDetailsBll)
        {
            _orderDetailsBll = orderDetailsBll ??
                throw new ArgumentNullException(nameof(orderDetailsBll));
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<OrderDetails_DTO>>> GetOrderDetails_Map()
        {
            return Ok(await _orderDetailsBll.GetOrderDetails_Map());
        }
        [HttpPost]
        public async Task<ActionResult<bool>> PostOrderDetails_Map(int CartsId, int OrdersId)
        {
            return Ok(await _orderDetailsBll.PostOrderDetails_Map(CartsId, OrdersId));
        }
    }
}
