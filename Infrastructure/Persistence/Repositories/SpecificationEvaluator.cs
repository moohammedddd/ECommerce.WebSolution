using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal static class SpecificationEvaluator
    {
        public static IQueryable<T> CreateQuery<T>(IQueryable<T> inputQuery, ISpecifications<T> specification) where T : class
        {

            var query = inputQuery;
            if(specification.Criteria is not null) //Filter 
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDescending is not null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            //if (specification.Take > 0)
            //{
            //    query = query.Take(specification.Take);
            //}

            //foreach(var include in specification.IncludeExpression)
            //{
            //    query.Include(include); // p => p.ProdcutBrand
            //}
            if (!specification.IsPagingEnabled)
            {
                if (specification.Skip > 0)
                {
                    query = query.Skip(specification.Skip);
                }

                if (specification.Take > 0)
                {
                    query = query.Take(specification.Take);
                }
            }
            else
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            query = specification.IncludeExpression
                    .Aggregate(query, (ConcurrentQueue, include)
                    => ConcurrentQueue.Include(include));
           


            return query;
            
        }   
    }
}
