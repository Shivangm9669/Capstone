using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.WishlistController.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly EcommerceDbContext _context;

        public WishlistService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Wishlist>> GetWishlist(Guid userId)
        {
            return await _context.Wishlists.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task<Wishlist> AddToWishlist(Wishlist wishlistItem)
        {
            _context.Wishlists.Add(wishlistItem);
            await _context.SaveChangesAsync();
            return wishlistItem;
        }

        public async Task<bool> RemoveFromWishlist(Guid wishlistItemId)
        {
            var wishlistItem = await _context.Wishlists.FindAsync(wishlistItemId);
            if (wishlistItem == null)
                return false;

            _context.Wishlists.Remove(wishlistItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
