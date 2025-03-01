using EcommerceAPI.Models;


namespace EcommerceAPI.Controllers.CartController.Services
{
    public interface ICartService
    {
        Task<Cart?> GetCartByUserId(Guid userId);
        Task<Cart> CreateCart(Guid userId);
        Task<bool> AddItemToCart(Guid cartId, CartItem cartItem);
        Task<bool> RemoveItemFromCart(Guid cartId, Guid cartItemId);
        Task<bool> ClearCart(Guid cartId);
    }
}
