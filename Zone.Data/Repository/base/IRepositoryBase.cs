using System.Linq.Expressions;

namespace Zone.Data.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        RepositoryContext RepositoryContext { get; set; }
        Task<IQueryable<T>> FindAll();
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task<T> FindByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
