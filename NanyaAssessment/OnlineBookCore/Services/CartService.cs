using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Core.IServices;
using OnlineBookStore.Data.Context;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Core.Services
{
    public class CartService : ICartService
    {
        private readonly OnlineBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CartService(OnlineBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartDTO> GetCartByUserIdAsync(string userId)
        {
            var cart = await _context.Carts.Include(c => c.Books).FirstOrDefaultAsync(c => c.UserId == userId);
            return _mapper.Map<CartDTO>(cart);
        }

        public async Task AddBookToCartAsync(string userId, string bookId)
        {
            var cart = await _context.Carts.Include(c => c.Books).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }

            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                cart.Books.Add(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveBookFromCartAsync(string userId, string bookId)
        {
            var cart = await _context.Carts.Include(c => c.Books).FirstOrDefaultAsync(c => c.UserId == userId);
            if (cart != null)
            {
                var book = cart.Books.FirstOrDefault(b => b.Id == bookId);
                if (book != null)
                {
                    cart.Books.Remove(book);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
