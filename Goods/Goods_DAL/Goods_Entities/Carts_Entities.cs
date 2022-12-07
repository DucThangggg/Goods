using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class Carts_Entities
    {
        // Data Carts
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CartsId { get; set; }
        [Required]
        public int ProductAllPrice { get; set; }
        [Required]
        public int Amount { get; set; }
        [ForeignKey("ProductId")]
        public Items_Entities? items_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("UserId")]
        public User_Entities? user_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int UserId { get; set; }
    }
}
