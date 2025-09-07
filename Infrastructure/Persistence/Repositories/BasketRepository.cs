using Domain.Contracts;
using Domain.Models.Baslets;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class BasketRepository (IConnectionMultiplexer _connection): IBasketRepository
    {
        private readonly IDatabase _database = _connection.GetDatabase();
        public async Task<CustomerBasket?> CreateOrUpdate(CustomerBasket basket, TimeSpan? timeToLive = null)
        {
            var jsonBasket = JsonSerializer.Serialize(basket);
            var isCreatedOrUpdated =    await _database.StringSetAsync(basket.Id, jsonBasket, timeToLive?? TimeSpan.FromDays(7));
                return isCreatedOrUpdated ? await GetAsync(basket.Id) : null;
        }

        public async Task DeleteAsync(string Id)
        {
            await _database.KeyDeleteAsync(Id);
        }

        public async Task<CustomerBasket> GetAsync(string id)
        {
            var baske = await _database.StringGetAsync(id);
            if (baske.IsNullOrEmpty) return null;
            return JsonSerializer.Deserialize<CustomerBasket>(baske)!;
           
        }
    }
}
