using System.Linq.Expressions;

namespace NinetyOneTechnicalTestSolution.Repositories
{
    public interface IRepository
    {
        Task<IList<T>> GetAllAsync<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
