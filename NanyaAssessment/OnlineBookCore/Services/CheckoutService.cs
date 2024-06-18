using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Core.IServices;
using OnlineBookStore.Data.Context;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Core.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly OnlineBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CheckoutService(OnlineBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task SimulateCheckoutAsync(string userId, string paymentMethod)
        {
            var cart = await _context.Carts.Include(c => c.Books).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart != null)
            {
                foreach (var book in cart.Books)
                {
                    var purchaseHistory = new PurchaseHistory
                    {
                        UserId = userId,
                        BookId = book.Id,
                        PaymentMethod = paymentMethod
                    };
                    _context.PurchaseHistories.Add(purchaseHistory);
                }

                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PurchaseHistoryDTO>> GetPurchaseHistoryByUserIdAsync(string userId)
        {
            var purchaseHistories = await _context.PurchaseHistories
                .Where(ph => ph.UserId == userId)
                // .Include(ph => ph.Book)
                .ToListAsync();
            return _mapper.Map<IEnumerable<PurchaseHistoryDTO>>(purchaseHistories);
        }
    }
}
