namespace CRUDApi.Interface
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task StatusEnable(long id);
        Task StatusDisable(long id);
        Task Delete(T entity);
    }
}