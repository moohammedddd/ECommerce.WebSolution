using Domain.Models.Proudcts;
using Shared.DataTransferObject.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specification
{
    public class ProductCountSpecifications(ProductQueryParmeters productQueryParmeters )
        :BaseSpecifications<Product>(CreateCriteria(productQueryParmeters))

    {
        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParmeters productQueryParmeters)
        {
            return prod =>
             (!productQueryParmeters.BrandId.HasValue || prod.BrandId == productQueryParmeters.BrandId.Value) &&
             (!productQueryParmeters.TypeId.HasValue || prod.TypeId == productQueryParmeters.TypeId.Value) &&
             (string.IsNullOrEmpty(productQueryParmeters.Search) ||
             prod.Name.ToLower().Contains(productQueryParmeters.Search.ToLower()));


        }

    }
}
