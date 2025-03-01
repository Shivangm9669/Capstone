using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers.WishlistController.Services
{
    public interface IWishlistService
    {
        Task<IEnumerable<Wishlist>> GetWishlist(Guid userId);
        Task<Wishlist> AddToWishlist(Wishlist wishlistItem);
        Task<bool> RemoveFromWishlist(Guid wishlistItemId);
    }
}
