namespace OnlineBookStore.Data.Repository.Interface
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepo { get; }
        void Save();
    }
}
