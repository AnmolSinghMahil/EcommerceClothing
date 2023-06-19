using System.ComponentModel.DataAnnotations;

namespace EcommerceClothing.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Required]
        public string CategoryName{ get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
