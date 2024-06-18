namespace OnlineBookStore.Model.Entities
{
    public class Cart : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
