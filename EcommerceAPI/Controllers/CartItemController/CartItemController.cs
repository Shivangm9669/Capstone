using EcommerceAPI.Controllers.CartItemController.Services;
using EcommerceAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.CartItemController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        // GET: api/cartitem/{cartId}
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartItems(Guid cartId)
        {
            var cartItems = await _cartItemService.GetCartItems(cartId);
            return Ok(cartItems);
        }

        // GET: api/cartitem/details/{cartItemId}
        [HttpGet("details/{cartItemId}")]
        public async Task<IActionResult> GetCartItemById(Guid cartItemId)
        {
            var cartItem = await _cartItemService.GetCartItemById(cartItemId);
            if (cartItem == null)
                return NotFound(new { message = "Cart item not found" });

            return Ok(cartItem);
        }

        // POST: api/cartitem
        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CartItem cartItem)
        {
            var newCartItem = await _cartItemService.AddCartItem(cartItem);
            return CreatedAtAction(nameof(GetCartItemById), new { cartItemId = newCartItem.Id }, newCartItem);
        }

        // PUT: api/cartitem/{cartItemId}
        [HttpPut("{cartItemId}")]
        public async Task<IActionResult> UpdateCartItem(Guid cartItemId, [FromBody] CartItem cartItem)
        {
            var updated = await _cartItemService.UpdateCartItem(cartItemId, cartItem);
            if (!updated)
                return NotFound(new { message = "Cart item not found" });

            return NoContent();
        }

        // DELETE: api/cartitem/{cartItemId}
        [HttpDelete("{cartItemId}")]
        public async Task<IActionResult> RemoveCartItem(Guid cartItemId)
        {
            var deleted = await _cartItemService.RemoveCartItem(cartItemId);
            if (!deleted)
                return NotFound(new { message = "Cart item not found" });

            return NoContent();
        }
    }
}
