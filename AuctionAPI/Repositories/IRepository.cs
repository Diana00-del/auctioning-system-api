namespace AuctionAPI.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long id);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Delete(long id);
    }
}
