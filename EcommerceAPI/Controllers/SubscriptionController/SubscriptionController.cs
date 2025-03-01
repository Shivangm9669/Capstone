using EcommerceAPI.Controllers.SubscriptionController.Services;
using EcommerceAPI.Models;

using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers.SubscriptionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        // GET: api/subscription/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetSubscriptionByUserId(Guid userId)
        {
            var subscription = await _subscriptionService.GetSubscriptionByUserId(userId);
            if (subscription == null)
                return NotFound(new { message = "Subscription not found." });

            return Ok(subscription);
        }

        // POST: api/subscription
        [HttpPost]
        public async Task<IActionResult> CreateSubscription([FromBody] Subscription subscription)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdSubscription = await _subscriptionService.CreateSubscription(subscription);
            return CreatedAtAction(nameof(GetSubscriptionByUserId), new { userId = createdSubscription.UserId }, createdSubscription);
        }

        // DELETE: api/subscription/{subscriptionId}
        [HttpDelete("{subscriptionId}")]
        public async Task<IActionResult> CancelSubscription(Guid subscriptionId)
        {
            var result = await _subscriptionService.CancelSubscription(subscriptionId);
            if (!result)
                return NotFound(new { message = "Subscription not found." });

            return NoContent();
        }
    }
}
