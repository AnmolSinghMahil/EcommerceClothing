using EcommerceClothing.Models;
using System.Threading.Tasks;

namespace EcommerceClothing.Services
{
    public interface ICartRepository
    {
        string GetUserID();
        Task<ShoppingCart> GetShoppingCart();
        Task AddCartItem(int prodId, int qty);
        Task RemoveCartItem(int prodId);
        Task<ShoppingCart> GetUserCart();

        Task<int> GetCount();
    }
}
