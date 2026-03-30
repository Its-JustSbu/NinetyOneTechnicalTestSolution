using Microsoft.EntityFrameworkCore;
using NinetyOneTechnicalTestSolution.Models;
using System.Linq.Expressions;

namespace NinetyOneTechnicalTestSolution.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _appDbContext;
        public Repository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        async Task IRepository.AddAsync<T>(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        async Task<IList<T>> IRepository.GetAllAsync<T>()
        {
            var entries = _appDbContext.Set<T>();
            return await entries.ToListAsync();
        }

        async Task<IList<T>> IRepository.GetByAsync<T>(Expression<Func<T, bool>> expression)
        {
            var entries = _appDbContext.Set<T>().Where(expression).AsNoTracking();
            return await entries.ToListAsync();
        }
    }
}
