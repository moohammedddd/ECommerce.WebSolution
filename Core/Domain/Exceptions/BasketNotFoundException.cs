using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class BasketNotFoundException(string basketkey)
        :NotFoundException($"Basket with This Id :{basketkey} Is Not Found ")
    {
    }
}
