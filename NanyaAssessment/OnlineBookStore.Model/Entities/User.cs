using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OnlineBookStore.Model.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; }
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<PurchaseHistory> PurchaseHistories { get; set; } = new List<PurchaseHistory>();
    }
}
    