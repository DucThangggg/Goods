using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class OrderDetails_Entities
    {
        // Data Orders
        // OrderDetails lấy thông tin của Items (ProductName thông qua ProductID)
        // OrderDetails lấy thông tin số lượng và giá của bảng Carts thông qua code gán biến của mình
        // OrderDetails lấy một số thông tin của bảng Order sử dụng cho lệnh GetOrderDetails
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OrderDetailsId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public int ProductAllPrice { get; set; }
        [ForeignKey("ProductId")]
        public Items_Entities? items_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("OrdersId")]
        public Orders_Entities? orders_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int OrdersId { get; set; }

    }
}
