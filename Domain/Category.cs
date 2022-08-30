using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Nft.Domain
{
    public class Category
    {

        public Category()
        {
            Products = new Collection<Product>();
        }
        public int CategoryId { get; set; }
        [Required]
        [StringLength(80)]
        public string? CategoryName { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
        
    }
}
