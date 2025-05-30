using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specification
{
    public abstract class BaseSpecifications<T> : ISpecifications<T> where T : class
    {
        public BaseSpecifications(Expression<Func<T, bool>> criteria = null) // Filter
        {
            Criteria = criteria;
        }


        public Expression<Func<T, bool>>? Criteria  {get; private set ;}

        public List<Expression<Func<T, object>>> IncludeExpression { get; } = [] ; // Loading Nav Property 
         protected void AddInclude(Expression<Func<T, object>> include)
        {
            IncludeExpression.Add(include);
        }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public Expression<Func<T, object>>? OrderBy { get; private set; }

    
        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDesc)
        {
            OrderByDescending = orderByDesc;
        }
        protected void ApplyTake(int take)
        {
            Take = take;
        }

        public int Skip { get; private set; }
        

        public bool IsPagingEnabled { get; private set; }

        protected void ApplyPaging(int pageSize, int PageIndex)
        {
            Skip = (PageIndex -1 ) * PageIndex;
            Take = pageSize;
            IsPagingEnabled = true;
        }



    }
}
