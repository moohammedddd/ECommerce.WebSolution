using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<T> where T: class
    {
        //_storeDbContext.Set<T>()Where(Expression<Func<T,bool>)
        Expression<Func<T, bool>> Criteria { get; } // For Filter


        //_storeDbContext.Set<T>().Select(Expression<func<T,object>>)

        //Include
        List<Expression<Func<T, object>>> IncludeExpression { get; } // For Include

        //_storeDbContext.Set<T>().Where(Specification.Criteria).Include(IncludeExpression[0]))

        Expression<Func<T, object>>? OrderBy { get; } // For Order Asc
        Expression<Func<T, object>>? OrderByDescending { get; } // For Order Desc

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; } // For Pagination

    }
}
