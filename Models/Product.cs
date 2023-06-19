using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceClothing.Models
{
   /* public enum Colors
    {
        Black,
        Blue,
        White,
        Brown,
        Grey

    }
    public enum Sizes
    {
        Small,
        Medium,
        Large
    }*/
    public class Product
    {
        public int ID{ get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name= "Product Name")]
        public string Name { get; set; }   
        
        public string Img { get; set; }
        //remove Color 6/13/23
       /* public Colors Color { get; set; }*/
        
        //remove Size 6/13/23
        /*public Sizes Size { get; set; }*/

        [Required]
        public double Price { get; set; }  
        //removed qty 6/13/23
        /*public int Qty { get; set; }*/

        /*public ICollection<CartItem> CartItems { get; set; }*/ //might not need it, or change it not be ICollection 
        public ICollection<ProductCategory> ProductCategories { get; set;}

        //6/12/23 for images table
        //navigation property - public ICollection<Images> Images {get;set;}
        //foreign key - public int ImageID {get; set;}

        //6/13/23 for available products
       /* public int AvailabeProductID { get; set; } *///might not need it
        public ICollection<AvailableProduct> AvailableProducts { get; set; }

    }
}
