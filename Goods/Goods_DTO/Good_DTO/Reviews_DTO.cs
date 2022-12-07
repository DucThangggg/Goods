using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Goods.Goods_DTO
{
    public class Reviews_DTO
    {
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Rating { get; set; } = string.Empty;
        [Required]
        public string Content { get; set; } = string.Empty;
        [JsonIgnore]
        [Required]
        public int ProductId { get; set; }
    }
}
