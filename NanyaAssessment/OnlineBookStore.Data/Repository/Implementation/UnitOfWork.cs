using OnlineBookStore.Data.Context;
using OnlineBookStore.Data.Repository.Interface;

namespace OnlineBookStore.Data.Repository.Implementation
{
    public class UnitOfWork :IUnitOfWork
    {
      
        public IBookRepository BookRepo { get; private set; }
        private OnlineBookStoreDbContext _db;

        public UnitOfWork(OnlineBookStoreDbContext db)
        {
            _db = db;
        
            BookRepo = new BookRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
