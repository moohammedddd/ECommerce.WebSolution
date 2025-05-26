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
    public class ServiceManager(IUnitOfWork _unitOfWork ,IMapper _mapper ): IServicesManager
    {
        private readonly Lazy<ProductServices> _LazyProductServices=
            new Lazy<ProductServices>(() => new ProductServices(_unitOfWork , _mapper));
        public IProductServices ProductServices =>  _LazyProductServices.Value;
    }
}
