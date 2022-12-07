using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DAL.Goods_Entities
{
    public class User_Entities
    {
        // Data User
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string RefreshToken { get; set; } = string.Empty;
        [Required]
        public DateTime TokenCreated { get; set; }
        [Required]
        public DateTime TokenExpires { get; set; }
        public List<Carts_Entities> ListCarts { get; set; } = new List<Carts_Entities>();
        public List<Reviews_Entities> ListReviews { get; set; } = new List<Reviews_Entities>();
        public List<Orders_Entities> ListOrders { get; set; } = new List<Orders_Entities>();
    }
}
