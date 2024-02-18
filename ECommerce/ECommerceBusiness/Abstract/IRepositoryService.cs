namespace ECommerceBusiness.Abstract
{
    public interface IRepositoryService<T> where T : class
    {
        Task TAdd(T entity);
        Task TDelete(T entity);
        Task TUpdate(T entity);
        Task<T> TGetByID(int id);
        Task<List<T>> TGetListAll();
    }
}
