using Microsoft.AspNetCore.Identity;

namespace EcommerceClothing.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public IdentityUser User { get; set; }//new
        public ICollection<CartItem> CartItems { get; set;}

        
    }
}
