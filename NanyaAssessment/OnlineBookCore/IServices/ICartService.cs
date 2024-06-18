using OnlineBookStore.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Core.IServices
{
    public interface ICartService
    {       
        Task<CartDTO> GetCartByUserIdAsync(string userId);
        Task AddBookToCartAsync(string userId, string bookId);
        Task RemoveBookFromCartAsync(string userId, string bookId);       
    }
}
