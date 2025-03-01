using EcommerceAPI.Models;

namespace EcommerceAPI.Controllers.CartItemController.Services
{
    public interface ICartItemService
    {
        Task<IEnumerable<CartItem>> GetCartItems(Guid cartId);
        Task<CartItem?> GetCartItemById(Guid cartItemId);
        Task<CartItem> AddCartItem(CartItem cartItem);
        Task<bool> UpdateCartItem(Guid cartItemId, CartItem cartItem);
        Task<bool> RemoveCartItem(Guid cartItemId);
    }
}
