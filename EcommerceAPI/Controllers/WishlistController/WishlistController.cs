using EcommerceAPI.Controllers.WishlistController.Services;
using EcommerceAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.WishlistController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistService _wishlistService;

        public WishlistController(IWishlistService wishlistService)
        {
            _wishlistService = wishlistService;
        }

        // GET: api/wishlist/{userId}
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWishlist(Guid userId)
        {
            var wishlist = await _wishlistService.GetWishlist(userId);
            return Ok(wishlist);
        }

        // POST: api/wishlist
        [HttpPost]
        public async Task<IActionResult> AddToWishlist([FromBody] Wishlist wishlistItem)
        {
            var newWishlistItem = await _wishlistService.AddToWishlist(wishlistItem);
            return CreatedAtAction(nameof(GetWishlist), new { userId = wishlistItem.UserId }, newWishlistItem);
        }

        // DELETE: api/wishlist/{wishlistItemId}
        [HttpDelete("{wishlistItemId}")]
        public async Task<IActionResult> RemoveFromWishlist(Guid wishlistItemId)
        {
            var removed = await _wishlistService.RemoveFromWishlist(wishlistItemId);
            if (!removed)
                return NotFound(new { message = "Wishlist item not found" });

            return NoContent();
        }
    }
}
