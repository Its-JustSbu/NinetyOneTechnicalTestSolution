using System.Linq.Expressions;

namespace NinetyOneTechnicalTestSolution.Repositories
{
    public interface IRepository
    {
        Task<IList<T>> GetAllAsync<T>() where T : class;
        Task AddRangeAsync<T>(List<T> entities) where T : class;
        Task SaveChangesAsync();
    }
}
