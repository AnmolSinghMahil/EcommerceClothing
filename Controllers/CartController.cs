using EcommerceClothing.Data;
using EcommerceClothing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EcommerceClothing.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext context)
        {
           _context = context;
        }
       
        public async Task<IActionResult> Index()
        {

            var items = await _context.CartItems
                            .Include(p=>p.Product)
                            .AsNoTracking()
                            .ToListAsync();
            
            return View(items); 
        }
        
        public async Task<IActionResult> AddToCart(int id, int qty)
        {
            /*ICollection<Product> products = await _context.Products.Where(p => p.ID == id).ToListAsync();*/
            var item = new CartItem
            {
                ProductId =id,
                Qty = qty
            };
            try
            {
                _context.CartItems.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbException ex)
            {

            }
            return RedirectToAction("Product", "Index");

        }
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                var product = await _context.CartItems.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product == null) { return RedirectToAction("Index"); }
                _context.CartItems.Remove(product);
                await _context.SaveChangesAsync();
            }catch (DbException ex)
            {
                ModelState.AddModelError("", @$"Unable to save changes.
                                Try again, and if the problem persists,
                                  see your system administrator.");
            }
            return RedirectToAction("Index");
        }

       
    }
}
