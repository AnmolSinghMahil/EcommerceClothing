using System.ComponentModel.DataAnnotations;

namespace EcommerceClothing.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        
        public int ShoppingCartID { get; set; }//new

        [Display(Name = "Quantity")]

        
        public int Qty { get; set; }

        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }//new
    }
}
