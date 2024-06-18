using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookStore.Model.Entities
{
    public class Book : BaseEntity
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        public int GenreId { get; set; }
        public string UserId { get; set; } // Foreign key to User

        // Navigation properties
        public User User { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<PurchaseHistory> PurchaseHistories { get; set; }
        public string ImageUrl { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishedDate { get; set; }
        public int TotalPageCount { get; set; }
        public string BookContent { get; set; }
    }
}
