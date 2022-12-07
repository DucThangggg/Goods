using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goods.Goods_DTO
{
    public class Orders_DTO
    {
        [JsonIgnore]
        [Required]
        public int OrdersId { get; set; }
        [Required]
        public DateOnly OrdersDate { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShipName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string ShipAddress { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string ShipPhone { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;
    }
}
