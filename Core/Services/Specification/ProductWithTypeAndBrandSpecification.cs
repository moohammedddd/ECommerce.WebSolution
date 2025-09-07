using Domain.Models.Proudcts;
using Shared.DataTransferObject.Product;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specification
{
    public class ProductWithTypeAndBrandSpecification:BaseSpecifications<Product>
    {
        // To Get Product By Id 
        public ProductWithTypeAndBrandSpecification(int id):base(prod => prod.Id == id )
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);

        }

        //To Get All Product
        public ProductWithTypeAndBrandSpecification(ProductQueryParmeters productQueryParmeters) : base(CreateCriteria(productQueryParmeters))
        {
            AddInclude(p => p.ProductBrand);
            AddInclude(p => p.ProductType);
            ApplySorting(productQueryParmeters);
            ApplyPaging(productQueryParmeters.PageSize, productQueryParmeters.PageIndex);


        }

        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParmeters productQueryParmeters)
        {
            return prod =>
             (!productQueryParmeters.BrandId.HasValue || prod.BrandId == productQueryParmeters.BrandId.Value) &&
             (!productQueryParmeters.TypeId.HasValue || prod.TypeId == productQueryParmeters.TypeId.Value) &&
             (string.IsNullOrEmpty(productQueryParmeters.Search) ||
             prod.Name.ToLower().Contains(productQueryParmeters.Search.ToLower()));


        }

        private void ApplySorting(ProductQueryParmeters productQueryParmeters)
        {
            switch (productQueryParmeters.productSortingOptions)
            {
                case ProductSortingOptions.NameAsc:
                    ApplyOrderBy(prod => prod.Name);
                    break;

                case ProductSortingOptions.NameDesc:
                    ApplyOrderByDescending(prod => prod.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    ApplyOrderBy(prod => prod.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    ApplyOrderByDescending(prod => prod.Price);
                    break;

            }
        }
          
        }


    }
