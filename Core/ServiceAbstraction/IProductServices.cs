using Shared;
using Shared.DataTransferObject.Product;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
   public interface IProductServices
    {  
        //Get All Products
        Task<PaginatedResponse<ProductResponse>> GetAllProductAsync(ProductQueryParmeters productQueryParmeters);
        //Get Products By Id 
        Task<ProductResponse> GetProductByIdAsync(int id);

        //Get ProductBrands
        Task<IEnumerable<BrandResponse>> GetAllBrandsAsync();
      

        //Get ProductType
        Task<IEnumerable<TypeResponse>> GetAllTypesAsync();

        Task<IEnumerable<ProductResponse>> GetTopThreeExpensiveProductsAsync();
    }
}
