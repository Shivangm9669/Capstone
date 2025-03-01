using EcommerceAPI.Models;


namespace EcommerceAPI.Controllers.SubscriptionController.Services
{
    public interface ISubscriptionService
    {
        Task<Subscription?> GetSubscriptionByUserId(Guid userId);
        Task<Subscription> CreateSubscription(Subscription subscription);
        Task<bool> CancelSubscription(Guid subscriptionId);
    }
}
