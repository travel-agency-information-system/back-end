using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.Core.Domain.Encounters;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using FluentResults;
using System.Reflection.Metadata.Ecma335;

namespace Explorer.Encounters.Core.UseCases
{
    public class InternalCustomerService : BaseService<CustomerDto, Customer>, IInternalCustomerService
    {
        private readonly ICustomerService _customerService;
        public InternalCustomerService(IMapper mapper, ICustomerService customerService) : base(mapper)
        {
            _customerService = customerService;
        }

        public Result<CustomerDto> AddXpToCustomer(int customerId, int newXp)
        {
            CustomerDto customer = new CustomerDto();
            try
            {
                customer = _customerService.GetByUser(customerId).Value;
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }


            try
            {
                customer.Xp += newXp;
                customer.Level = (customer.Xp / 40) + 1; //postavi level, povecava se na svakih 40xp
                var result = _customerService.Update(customer).Value;
                return result;
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }

        }

    }
}
