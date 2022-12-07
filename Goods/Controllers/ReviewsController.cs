using Goods.Goods_BLL.Service.Implement;
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
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        public IReviewsBLL _reviewsBll;
        // Hàm khởi tạo
        public ReviewsController(IReviewsBLL reviewsBll)
        {
            _reviewsBll = reviewsBll ??
                throw new ArgumentNullException(nameof(reviewsBll));
        }
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Reviews_Show>>> GetReviews_Map()
        {
            return Ok(await _reviewsBll.GetReviews_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Reviews_DTO>>> PostReviews_Map(Reviews_DTO Review_Post)
        {
            // Lấy được tên từ bảng User nhưng vẫn dùng thêm ở Mapper để hiện thị UserName
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(await _reviewsBll.PostReviews_Map(Review_Post, userName));
        }
    }
}
