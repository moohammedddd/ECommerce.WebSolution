using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models.Baslets;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class BasketServices(IBasketRepository _basketRepository,
                                                IMapper _mapper): IBasketService
    {
        public async Task DeleteAsync(string id)
        => await  _basketRepository.DeleteAsync(id);
          
        public async Task<BasketDto> GetAsync(string id)
        {
            var basket = await _basketRepository.GetAsync(id) ?? throw new  BasketNotFoundException(id);
            return _mapper.Map<BasketDto>(basket);


        }

        public async Task<BasketDto> UpdateAsync(BasketDto basketDto)
        {
            var basket = _mapper.Map<CustomerBasket>(basketDto);
            var updatedBasket = await _basketRepository.CreateOrUpdate(basket) ??
                throw new Exception("Cant Create Baket");
            return _mapper.Map<BasketDto>(updatedBasket);
           

        }
    }
}
