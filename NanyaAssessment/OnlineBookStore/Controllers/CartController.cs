using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Core.IServices;
using OnlineBookStore.Data.DTO;


namespace OnlineBookStore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDTO>> GetCartByUserId(string userId)
        {
            var cart = await _cartService.GetCartByUserIdAsync(userId);
            if (cart == null)
            {
                return NotFound();
            }

            return Ok(cart);
        }

        [HttpPost("{userId}/add/{bookId}")]
        public async Task<IActionResult> AddBookToCart(string userId, string bookId)
        {
            await _cartService.AddBookToCartAsync(userId, bookId);
            return Ok();
        }

        [HttpDelete("{userId}/remove/{bookId}")]
        public async Task<IActionResult> RemoveBookFromCart(string userId, string bookId)
        {
            await _cartService.RemoveBookFromCartAsync(userId, bookId);
            return Ok();
        }
    }
}
