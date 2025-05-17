using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
   public class Product:BaseEntity<int>
    {
        public string Description { get; set; } = default!;
        public string PictureUrl { get; set; } = default!;
        public decimal Price { get; set; } 

        public int BrandId { get; set; } //Fk
        public ProductBrand ProductBrand { get; set; } // nav Prop

        public int TypeId { get; set; }//Fk
        public ProductType ProductType { get; set; } //nav prop



    }
}
