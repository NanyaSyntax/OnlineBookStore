using OnlineBookStore.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Core.IServices
{
    public interface ICheckoutService
    {
        Task SimulateCheckoutAsync(string userId, string paymentMethod);
        Task<IEnumerable<PurchaseHistoryDTO>> GetPurchaseHistoryByUserIdAsync(string userId);
    }
}

