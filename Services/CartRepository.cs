using EcommerceClothing.Data;
using EcommerceClothing.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace EcommerceClothing.Services
{
    public class CartRepository: ICartRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public CartRepository(ApplicationDbContext context,IHttpContextAccessor accessor,UserManager<IdentityUser> manager)
        {
            _context = context;
            _httpContextAccessor = accessor;   
            _userManager = manager;
        }
        public string GetUserID()
        {
            var principal =  _httpContextAccessor.HttpContext.User;
            //need to check if the user is authenticated/logged in or is it a guest
            string userID = _userManager.GetUserId(principal);
            if(userID == null)
            {
                userID = "";
                /*throw new Exception("User not found");*/
            }
            return userID;
        }
        public async Task<ShoppingCart> GetShoppingCart()
        {
            var userID = GetUserID();
            var getCart = await _context.ShoppingCart.FirstOrDefaultAsync(x=>x.UserID == userID);
            if (getCart == null)
            {
                getCart = new ShoppingCart
                {
                    UserID = userID
                };
                await _context.ShoppingCart.AddAsync(getCart);
                await _context.SaveChangesAsync();
                return getCart;
            }
            return getCart;
        }
        public async  Task AddCartItem(int prodId, int qty)
        {
            /*using var transaction =  _context.Database.BeginTransaction();*/
           /* try
            {*/
                var shoppingCart = await GetShoppingCart();
                var userId = GetUserID();
                var cartItem = await _context.CartItems.FirstOrDefaultAsync(a => a.Id == shoppingCart.Id & a.ProductId == prodId);

                if (cartItem is not null)
                {
                    cartItem.Qty += qty;
                    await _context.CartItems.AddAsync(cartItem);

                }
                else
                {
                    cartItem = new CartItem
                    {
                        ProductId = prodId,
                        Qty = qty,
                        ShoppingCartID = shoppingCart.Id
                    };
                   await _context.CartItems.AddAsync(cartItem);
                }
                await _context.SaveChangesAsync();
            /*    transaction.Commit();
            }catch (Exception )
            {
                new Exception("could not save");
            }*/
        }

        public async Task RemoveCartItem(int prodId)
        {
            var shoppingCart = await GetShoppingCart();
            var cartItem =await _context.CartItems.FirstOrDefaultAsync(a=>a.ProductId == prodId && a.ShoppingCartID == shoppingCart.Id);
            if (cartItem is null) { return; }
            //need to make a difference between product stock quantity and cartItem quantity
            /*else if (cartItem.Qty > 0) { 
                cartItem.Qty = cartItem.Qty - 1;
            }*/
            else
            {
                _context.CartItems.Remove(cartItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetUserCart()
        {
            string userId = GetUserID();
            var cart = await _context.ShoppingCart
                                    .Include(x => x.CartItems)
                                    .ThenInclude(p => p.Product)
                                    .FirstOrDefaultAsync(a => a.UserID == userId);
            return cart;
        }

        public async Task<int> GetCount()
        {
            ShoppingCart cart = await GetUserCart();
            if (cart == null) { return 0; }
            

            return cart.CartItems.ToList().Count();
        }
    }
}
