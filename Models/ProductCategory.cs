using System.ComponentModel;

namespace EcommerceClothing.Models
{


    public class ProductCategory
    {
        public int ID { get; set; }
        public int CategoryID { get; set; } 
        public int ProductID { get; set; }

        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
