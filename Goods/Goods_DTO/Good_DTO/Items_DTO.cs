using System.ComponentModel.DataAnnotations;

namespace Goods.Goods_DTO
{
    /// <summary>
    /// Information about an Item
    /// </summary>
    public class Items_DTO
    {
        /// <summary>
        /// The Product Name of the Items
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string ProductName { get; set; } = string.Empty;
        /// <summary>
        /// The Number Review of the Items
        /// </summary>
        [Required]
        public int NumberReview { get; set; }
        /// <summary>
        /// The Product Price of the Items
        /// </summary>
        [Required]
        public int ProductPrice { get; set; }
        /// <summary>
        /// The Product Remain of the Items
        /// </summary>
        [Required]
        public int ProductRemain { get; set; }
    }
}
