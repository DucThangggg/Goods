using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goods.Goods_DTO.Good_Show
{
    public class User_SignUp
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
        [JsonIgnore]
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = "User";
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;
    }
}
