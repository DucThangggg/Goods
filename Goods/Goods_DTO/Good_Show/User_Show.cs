using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DTO
{
    public class User_Show
    {
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
        [Required]
        public string AccessToken { get; set; } = string.Empty;
        [Required]
        public DateTime TokenCreated { get; set; }
        [Required]
        public DateTime TokenExpires { get; set; }
    }
}
