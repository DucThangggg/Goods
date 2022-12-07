using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DTO
{
    public class User_DTO
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
    }
}
