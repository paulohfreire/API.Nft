using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Nft.Domain
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        [StringLength(300)]
        public string? Description { get; set; }
        public string? File_url { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Expire_at { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }

    }
}
