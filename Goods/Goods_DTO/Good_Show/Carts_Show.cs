using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goods.Goods_DTO
{
    public class Carts_Show
    {
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int Amount { get; set; }
        [JsonIgnore]
        public int ProductAllPrice { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
    }
}
