using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Data.DTO
{
    public class PurchaseHistoryDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string PaymentMethod { get; set; }
    }
}
