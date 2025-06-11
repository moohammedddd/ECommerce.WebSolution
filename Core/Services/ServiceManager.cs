using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager(IUnitOfWork _unitOfWork ,IMapper _mapper , IBasketRepository _basketRepository ): IServicesManager
    {
        private readonly Lazy<ProductServices> _LazyProductServices=
            new Lazy<ProductServices>(() => new ProductServices(_unitOfWork , _mapper));
        public IProductServices ProductServices =>  _LazyProductServices.Value;


        private readonly Lazy<BasketServices> _LazyBasketService =
          new Lazy<BasketServices>(() => new BasketServices(_basketRepository, _mapper));
        public IBasketService BasketService => _LazyBasketService.Value;

    }
}
