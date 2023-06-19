using EcommerceClothing.Data;
using EcommerceClothing.Models;
using EcommerceClothing.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;
using System.Drawing;

namespace EcommerceClothing.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public  async Task<IActionResult> Index()
        {
            var products =await _context.Products
                    .Include(pc => pc.ProductCategories)
                    .ThenInclude(c=>c.Category)
                    .AsNoTracking()
                    .ToListAsync();
            return View(products);

        }


        public async Task<IActionResult> Details(int id, string color)
        {
            ViewData["Small"] = "disabled"; ViewData["Medium"] = "disabled"; ViewData["Large"] = "disabled"; ViewData["XtraLarge"] = "disabled";
            if (id== null)
            {
                return NotFound();
            }
            var product = await _context.Products
                    /*.Include(pc => pc.ProductCategories)
                        .ThenInclude(c => c.Category)*/
                    .Include(ap => ap.AvailableProducts)
                        .ThenInclude(s => s.Size)
                    .Include(ap => ap.AvailableProducts)
                        .ThenInclude(c => c.Color)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i=>i.ID ==id);
            if (product == null) { return NotFound(); }

            foreach (var item in product.AvailableProducts)
            {
                if (item.Color.Name == color)
                {
                    if (item.Size.Name == "Small")
                    {
                        ViewData["Small"] = "";
                    }
                    if (item.Size.Name == "Medium")
                    {
                        ViewData["Medium"] = "";
                    }
                    if (item.Size.Name == "Large")
                    {
                        ViewData["Large"] = "";
                    }
                }
            }
                return View(product);
        }

        public async Task<IActionResult> Search(string searchString)
        {

            if (searchString.IsNullOrEmpty()) { return RedirectToAction("Index"); }
            searchString.ToLower();
            IEnumerable<Product> products = await _context.Products
                                        .Include(pc=>pc.ProductCategories)
                                        .ThenInclude(p =>p.Category)
                                        .AsNoTracking()
                                        .Where(p=>p.Name.Contains(searchString))
                                        .ToListAsync();
               /* Products.Where(p => p.Name.Contains(searchString)).AsNoTracking().ToListAsync();*/
            return View("Index",products);
        }

    }
}
