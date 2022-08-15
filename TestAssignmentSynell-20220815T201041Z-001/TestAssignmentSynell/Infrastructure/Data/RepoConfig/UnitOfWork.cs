using System;
using System.Collections;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

namespace Infrastructure.Data.RepoConfig
{
    /** 
    Unit of work pattern helps us resolve 2 problems: 
    1. We need a facade for all of our repositories
    2. We need to have only 1 instance of the database for all repositories.!-- Changes are tracked by the repositories and services, but actual savings to database happen here.!-- And if there is a problem with saving changes, this class in it's Complete method will roll back transactions to avoid any partial updates.!-- Without this helper class, each repository will create it's own instance of the context, which is not good ))
    Repository method in this class creates an instance of the repository if one doesn't exist in _repositories HashTable, or returns an existing instance.!-- So the repository instances are dynamically created and fetched when they are needed.!-- 
**/
   public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;
        private Hashtable _repositories; 
        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null) {
                _repositories = new Hashtable();
            }
            //extract the name of TEntity we are passing (Product for example)
            var type = typeof(TEntity).Name;
            //if the hash table doesn't contain the entity with this name, we create an instance of the entity and add it to the hash table and then return the repository 
            if (!_repositories.ContainsKey(type)) {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context); 
                _repositories.Add(type, repositoryInstance); 
            }
            return (IGenericRepository<TEntity>) _repositories[type]; 
        }
    }
}