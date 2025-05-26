using Domain.Contracts;
using Domain.Models;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork(StoreDbContext _storeDbContext) : IUnitOfWork
    {
        private readonly Dictionary<string, object> _repositories = [];
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var typeName = typeof(TEntity).Name; // Product 
            if(!_repositories.ContainsKey(typeName))
  
            {
                var repo = new GenericRepository<TEntity, Tkey>(_storeDbContext);
                _repositories[typeName] = repo;
            }
            
              

            return (IGenericRepository<TEntity, Tkey>)_repositories[typeName];

        }
        
        public  async Task<int> SaveChanges()
        {
          return await  _storeDbContext.SaveChangesAsync();
        }
    }
}
