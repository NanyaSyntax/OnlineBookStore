using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Data.Context;
using OnlineBookStore.Data.Repository.Interface;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Data.Repository.Implementation
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly OnlineBookStoreDbContext _db;

        public BookRepository(OnlineBookStoreDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Book book)
        {
            var bookfromDb = _db.Books.FirstOrDefault(u => u.Id == book.Id);

            if (bookfromDb != null)
            {
                bookfromDb.Title = book.Title;
                bookfromDb.ISBN = book.ISBN;
                bookfromDb.PublishedDate = book.PublishedDate;
                bookfromDb.Publisher = book.Publisher;
                bookfromDb.UpdatedAt = DateTime.UtcNow;
                bookfromDb.TotalPageCount = book.TotalPageCount;
                bookfromDb.Description = book.Description;
                bookfromDb.GenreId = book.GenreId;
                bookfromDb.Author = book.Author;
                bookfromDb.BookContent = book.BookContent;
                if (bookfromDb.ImageUrl != null)
                {
                    bookfromDb.ImageUrl = book.ImageUrl;
                }
            }
        }
      
    }
}
