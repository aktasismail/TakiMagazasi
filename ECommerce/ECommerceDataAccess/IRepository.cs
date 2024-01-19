using System.Linq.Expressions;

namespace ECommerceDataAccess
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> GetAll();
	}
}
