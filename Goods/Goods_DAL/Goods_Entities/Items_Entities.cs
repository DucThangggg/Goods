using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class Items_Entities
    {
        // Data Items
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public int NumberReview { get; set; }
        [Required]
        public int ProductPrice { get; set; }
        [Required]
        public int ProductRemain{ get; set; }    // Còn lại
        // Một Items có thể có trong nhiều Carts, mỗi một item chứa trong một hàng của Carts
        public List<Carts_Entities> ListCarts { get; set; } = new List<Carts_Entities>();
        // Mỗi một Items có nhiều review
        public List<Reviews_Entities> ListReviews { get; set; } = new List<Reviews_Entities>();
    }
}
