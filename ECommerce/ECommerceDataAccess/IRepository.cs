using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerceDataAccess
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
	}
}
