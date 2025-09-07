using Domain.Models.Proudcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specification
{
    internal class TopThreeExpensiveProductsSpecification:BaseSpecifications<Product>
    {
        public TopThreeExpensiveProductsSpecification()
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

            ApplyOrderByDescending(p => p.Price);
            ApplyTake(3); //
        }
    }
}
