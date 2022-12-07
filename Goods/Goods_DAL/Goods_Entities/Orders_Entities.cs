using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class Orders_Entities
    {
        // Data Orders
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Required]
        public int SumOfPrice { get; set; }
        [ForeignKey("UserId")]
        public User_Entities? user_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int UserId { get; set; }
        public List<OrderDetails_Entities> ListOrderDetails { get; set; } = new List<OrderDetails_Entities>();
    }
}
