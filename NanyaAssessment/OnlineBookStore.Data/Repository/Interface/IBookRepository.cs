using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Data.Repository.Interface
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        void Update(Book product);

    }
}
