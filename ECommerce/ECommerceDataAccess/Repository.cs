
using ECommerceDataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task Delete(T entity)
        {
             _context.Remove(entity);
             await _context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
             return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}