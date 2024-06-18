using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookStore.Data.DTO
{
    public class BookDTO
    {       
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
    }

    public class AddBookDTO : BookDTO
    {
        public string BookId { get; set; } 
    }
}
