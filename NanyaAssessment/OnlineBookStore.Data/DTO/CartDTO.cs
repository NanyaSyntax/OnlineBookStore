using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Data.DTO
{
    public class CartDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
