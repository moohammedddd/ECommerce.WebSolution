using Domain.Models.Baslets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public  interface IBasketRepository
    {
        Task<CustomerBasket> GetAsync(string Id);
        Task<CustomerBasket?> CreateOrUpdate(CustomerBasket basket , TimeSpan? timeToLive = null);
        Task DeleteAsync(string Id);
    }
}

