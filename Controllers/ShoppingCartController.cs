using EcommerceClothing.Models;
using EcommerceClothing.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceClothing.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        
        public ShoppingCartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<IActionResult> Index()
        {
           var cart =  await _cartRepository.GetUserCart();
            
            return View(cart);
        }
        public async Task<IActionResult> AddToCart(int ID,int qty =1)
        {
            try
            {
                await _cartRepository.AddCartItem(ID, qty);
            }
            catch (Exception)
            {
                throw new Exception("Could not add item to cart");
            }
            return RedirectToAction("Index", "Product");
            
        }
        public async Task<IActionResult> RemoveFromCart(int ID)
        {
            try
            {
                await _cartRepository.RemoveCartItem(ID);
            }catch (Exception)
            {
                throw new Exception("Could not remove item from cart");
            }
            return RedirectToAction("Index");
        }
    }
}
