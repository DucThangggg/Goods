using Goods.Goods_BLL.Service.Interface;
using Goods.Goods_DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Goods.Controllers
{
    //[Route("api/v{version:apiVersion}/[controller]")]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        public IItemsBLL _itemsBll;
        const int maxEmployeeSize = 20;
        // Hàm khởi tạo
        public ItemsController(IItemsBLL itemsBll)
        {
            _itemsBll = itemsBll ??
                throw new ArgumentNullException(nameof(itemsBll));
        }
        // Get all
        //[Authorize]
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Items_DTO>>> GetItems_Map()
        {
            return Ok(await _itemsBll.GetItems_Map());
        }
        /// <summary>
        /// Post a items
        /// </summary>
        /// <param name="items_Post">include Items</param>
        /// <returns></returns>
        [HttpPost("Items")]
        public async Task<ActionResult<IEnumerable<Items_DTO>>> PostItems_Map(Items_DTO items_Post)
        {
            return Ok(await _itemsBll.PostItems_Map(items_Post));
        }
        /// <summary>
        /// Delete a items
        /// </summary>
        /// <param name="IDProduct">The Id Product of items</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Return the requested Items</response>
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteEmployeeID/{IDProduct}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeleteItemsID(int IDProduct)
        {
            return Ok(await _itemsBll.DeleteItemsID(IDProduct));
        }
    }
}
