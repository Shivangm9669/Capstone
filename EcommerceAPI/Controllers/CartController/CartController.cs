using EcommerceAPI.Controllers.CartController.Services;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EcommerceAPI.Controllers.CartController
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // 🔒 Extracts user ID from JWT token
        private Guid GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userIdClaim != null ? Guid.Parse(userIdClaim) : Guid.Empty;
        }

        // GET: api/cart
        [HttpGet]
        public async Task<IActionResult> GetCartByUserId()
        {
            var userId = GetUserIdFromToken();
            if (userId == Guid.Empty)
                return Unauthorized(new { message = "Invalid token." });

            var cart = await _cartService.GetCartByUserId(userId);
            if (cart == null)
                return NotFound(new { message = "Cart not found." });

            return Ok(cart);
        }

        // POST: api/cart/create
        [HttpPost("create")]
        public async Task<IActionResult> CreateCart()
        {
            var userId = GetUserIdFromToken();
            if (userId == Guid.Empty)
                return Unauthorized(new { message = "Invalid token." });

            var cart = await _cartService.CreateCart(userId);
            return Ok(cart);
        }

        // POST: api/cart/{cartId}/add
        [HttpPost("{cartId}/add")]
        public async Task<IActionResult> AddItemToCart(Guid cartId, [FromBody] CartItem cartItem)
        {
            var result = await _cartService.AddItemToCart(cartId, cartItem);
            if (!result)
                return NotFound(new { message = "Cart not found." });

            return Ok(new { message = "Item added to cart." });
        }

        // DELETE: api/cart/{cartId}/remove/{cartItemId}
        [HttpDelete("{cartId}/remove/{cartItemId}")]
        public async Task<IActionResult> RemoveItemFromCart(Guid cartId, Guid cartItemId)
        {
            var result = await _cartService.RemoveItemFromCart(cartId, cartItemId);
            if (!result)
                return NotFound(new { message = "Item not found in cart." });

            return Ok(new { message = "Item removed from cart." });
        }

        // DELETE: api/cart/{cartId}/clear
        [HttpDelete("{cartId}/clear")]
        public async Task<IActionResult> ClearCart(Guid cartId)
        {
            var result = await _cartService.ClearCart(cartId);
            if (!result)
                return NotFound(new { message = "Cart not found." });

            return Ok(new { message = "Cart cleared." });
        }
    }
}
