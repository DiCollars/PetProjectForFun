namespace DAL.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(int skip, int take);

        Task<T> Get(int id);

        Task Create(T item);

        Task Update(T item);

        Task Delete(int id);
    }
}
