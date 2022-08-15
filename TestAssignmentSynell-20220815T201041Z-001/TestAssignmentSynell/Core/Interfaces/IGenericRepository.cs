using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        //paging logic
        Task<int> CountAsync(ISpecification<T> spec);
        //updating, adding, and deleting. The methods are not async because we want to track the changes and the actual saving of changes into database are left to UnitOfWork
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}