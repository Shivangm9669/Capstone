using EcommerceAPI.Data;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Controllers.SubscriptionController.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly EcommerceDbContext _context;

        public SubscriptionService(EcommerceDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription?> GetSubscriptionByUserId(Guid userId)
        {
            return await _context.Subscriptions
                .FirstOrDefaultAsync(s => s.UserId == userId);
        }

        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task<bool> CancelSubscription(Guid subscriptionId)
        {
            var subscription = await _context.Subscriptions.FindAsync(subscriptionId);
            if (subscription == null)
                return false;

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
