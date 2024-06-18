namespace OnlineBookStore.Model.Entities
{
    public class PurchaseHistory : BaseEntity
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public string PaymentMethod { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
    }
}
