using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace API.Nft.Domain
{
    public class Owner
    {
        public Owner()
        {
            Products = new Collection<Product>(); 
        }
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string? Name { get; set; }
        [Required]
        [StringLength(300)]
        public string? Address { get; set; }
        
        public ICollection<Product>? Products { get; set; }
    }
}
