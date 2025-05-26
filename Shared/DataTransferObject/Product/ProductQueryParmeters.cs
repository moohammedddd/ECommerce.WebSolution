using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject.Product
{
    public class ProductQueryParmeters
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public ProductSortingOptions productSortingOptions { get; set; } 
        
        public string? Search { get; set; }
    }
}
