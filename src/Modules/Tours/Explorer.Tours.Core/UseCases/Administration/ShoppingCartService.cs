using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Administration
{
	public class ShoppingCartService : CrudService<ShoppingCartDto, ShoppingCart>, IShoppingCartService
	{
		private readonly IShoppingCartRepository _shoppingCartRepository;
		public ShoppingCartService(IShoppingCartRepository repository, IMapper mapper) : base(repository, mapper)
		{
			_shoppingCartRepository = repository;
		}
		public Result<bool> CheckIfShoppingCartExists(int touristId)
		{
			try
			{
				bool exists = _shoppingCartRepository.ShoppingCartExists(touristId);
				return Result.Ok(exists);
			}
			catch (Exception e)
			{
				return Result.Fail(FailureCode.NotFound).WithError(e.Message);
			}
		}

		public Result<ShoppingCartDto> GetShoppingCart(int touristId)
		{
			try
			{
				var result = _shoppingCartRepository.GetShoppingCart(touristId);
				return MapToDto(result);
			}
			catch (KeyNotFoundException e)
			{
				return Result.Fail(FailureCode.NotFound).WithError(e.Message);
			}
		}

	}
}
