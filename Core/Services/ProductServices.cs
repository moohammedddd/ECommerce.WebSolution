using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction;
using Services.Specification;
using Shared.DataTransferObject.Product;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices(IUnitOfWork _unitOfWork ,IMapper _mapper): IProductServices // use UnitOfWork because Services need to connect to db
    {
        public async Task<IEnumerable<BrandResponse>> GetAllBrandsAsync()

        {
            /// Get the function that in the UnitOfWork that is IGenericRepository that have update , delete and so on 
            /// GetAllAsync is the function that get all the data from the database it return IEnumerable of Brand 
            /// in this function now it return IEnumerable of BrandResponse then we need to map to this type from IEnumerable of Brand
            var repository = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repository.GetAllAsync(); 
            var result = _mapper.Map<IEnumerable<BrandResponse>>(brands);
            return result;

        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync(ProductQueryParmeters productQueryParmeters)

        {

            var specs = new  ProductWithTypeAndBrandSpecification(productQueryParmeters);// no filter with id
            var product = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(specs);
            var result =  _mapper.Map<IEnumerable<ProductResponse>>(product);
            return result;

        }

        public async Task<IEnumerable<TypeResponse>> GetAllTypesAsync()
        {
            var repository = _unitOfWork.GetRepository<ProductType, int>();
            var types = await repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TypeResponse>>(types);
            return result;
        }

   
        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {

            var specs = new ProductWithTypeAndBrandSpecification(id);//  filter with id
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specs);
            var result = _mapper.Map<ProductResponse>(product);
            return result;
        }

        public async Task<IEnumerable<ProductResponse>> GetTopThreeExpensiveProductsAsync()
        {
            var spec = new TopThreeExpensiveProductsSpecification();
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(spec);
            var result = _mapper.Map<IEnumerable<ProductResponse>>(products);
            return result;
        }


    }
}
