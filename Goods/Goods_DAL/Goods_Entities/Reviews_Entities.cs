using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class Reviews_Entities
    {
        // Data Reviews
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ReviewsId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Rating { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
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
