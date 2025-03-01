
using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.CartItemController.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly EcommerceDbContext _context;

        public CartItemService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(Guid cartId)
        {
            return await _context.CartItems.Where(ci => ci.CartId == cartId).ToListAsync();
        }

        public async Task<CartItem?> GetCartItemById(Guid cartItemId)
        {
            return await _context.CartItems.FindAsync(cartItemId);
        }

        public async Task<CartItem> AddCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();
            return cartItem;
        }

        public async Task<bool> UpdateCartItem(Guid cartItemId, CartItem cartItem)
        {
            var existingCartItem = await _context.CartItems.FindAsync(cartItemId);
            if (existingCartItem == null)
                return false;

            existingCartItem.Quantity = cartItem.Quantity;
            existingCartItem.ProductId = cartItem.ProductId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveCartItem(Guid cartItemId)
        {
            var cartItem = await _context.CartItems.FindAsync(cartItemId);
            if (cartItem == null)
                return false;

            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
