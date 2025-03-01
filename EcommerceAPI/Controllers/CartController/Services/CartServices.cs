using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.CartController.Services 
{
    public class CartService : ICartService
    {
        private readonly EcommerceDbContext _context;

        public CartService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartByUserId(Guid userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> CreateCart(Guid userId)
        {
            var cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<bool> AddItemToCart(Guid cartId, CartItem cartItem)
        {
            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null) return false;

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == cartItem.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
            }
            else
            {
                cart.CartItems.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItemFromCart(Guid cartId, Guid cartItemId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null) return false;

            var itemToRemove = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            if (itemToRemove == null) return false;

            cart.CartItems.Remove(itemToRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ClearCart(Guid cartId)
        {
            var cart = await _context.Carts.Include(c => c.CartItems)
                                           .FirstOrDefaultAsync(c => c.Id == cartId);
            if (cart == null) return false;

            cart.CartItems.Clear();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
