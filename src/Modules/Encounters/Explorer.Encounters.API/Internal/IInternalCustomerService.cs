using Explorer.Payments.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Internal
{
    public interface IInternalCustomerService
    {
        Result<CustomerDto> AddXpToCustomer(int customerId, int newXp);
    }
}
