using Domain.Models;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IUnitOfWork

    {
        Task<int> SaveChanges();
        //IGenericRepository<Product, int> ProductRepository { get; }
        //IGenericRepository<ProductBrand, int> ProductBrandRepository { get; }
        //IGenericRepository<ProductType, int> ProductTypeRepository { get; }
        IGenericRepository<TEntity, Tkey>GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
