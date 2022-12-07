using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DTO
{
    public class Orders_Show
    {
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
        [Required]
        public int SumOfPrice { get; set; }
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
    }
}
