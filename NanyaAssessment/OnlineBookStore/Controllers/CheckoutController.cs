using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Core.IServices;
using OnlineBookStore.Data.DTO;
namespace OnlineBookStore.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> Checkout(string userId, [FromQuery] string paymentMethod)
        {
            await _checkoutService.SimulateCheckoutAsync(userId, paymentMethod);
            return Ok();
        }

        [HttpGet("history/{userId}")]
        public async Task<ActionResult<IEnumerable<PurchaseHistoryDTO>>> GetPurchaseHistory(string userId)
        {
            var history = await _checkoutService.GetPurchaseHistoryByUserIdAsync(userId);
            return Ok(history);
        }
    }
}