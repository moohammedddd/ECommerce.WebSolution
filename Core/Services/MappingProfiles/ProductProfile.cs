using AutoMapper;
using Domain.Models.Proudcts;
using Microsoft.Extensions.Configuration;
using Shared.DataTransferObject.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            //     Source , Destination
            CreateMap<Product, ProductResponse>()
                .ForMember(dest => dest.BrandName,
                option => option.MapFrom(src => src.ProductBrand.Name))
                  .ForMember(dest => dest.TypeName,
                option => option.MapFrom(src => src.ProductType.Name))
                  .ForMember(dest => dest.PictureUrl, options =>
                  options.MapFrom<PictureUrlResolver>());


            CreateMap<ProductBrand, BrandResponse>();
            CreateMap<ProductType, TypeResponse>();



        }
   
    
    
    }


    public class PictureUrlResolver(IConfiguration _configuration):IValueResolver<Product, ProductResponse, string>
    {
        public string Resolve(Product source, ProductResponse destination, string destMember, ResolutionContext context)
        {

            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["BaseUrl"]}{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
    

 }

