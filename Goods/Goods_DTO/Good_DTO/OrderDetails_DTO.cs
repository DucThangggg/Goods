using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DTO
{
    public class OrderDetails_DTO
    {
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int Amount { get; set; }
        [Required]
        public int ProductAllPrice { get; set; }
        [Required]
        public int ProductId { get; set; }
        //[Required]
        //public int CartsId { get; set; }
        [Required]
        public int OrdersId { get; set; }
    }
}
