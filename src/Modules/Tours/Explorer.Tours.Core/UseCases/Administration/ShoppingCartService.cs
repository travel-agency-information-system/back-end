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
		private readonly ITourPurchaseTokenRepository _tourPurchaseTokenRepository;
		public ShoppingCartService(IShoppingCartRepository repository, IMapper mapper, ITourPurchaseTokenRepository tourPurchaseTokenRepository) : base(repository, mapper)
		{
			this._shoppingCartRepository = repository;
			this._tourPurchaseTokenRepository = tourPurchaseTokenRepository; //nisam sigurna da ide ovako, proveri 

        }

		// za obicni tip promenljive
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

		// za objekat
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

		//nzm jel dobro, sta treba da vraca 
        public Result<ShoppingCartDto> CheckoutShoppingCart(int touristId)
        {
            try
            {
                var result = _shoppingCartRepository.GetShoppingCart(touristId);

				foreach(var item in result.Items)
				{
					var newToken = new TourPurchaseToken(touristId, item.TourId);
					_tourPurchaseTokenRepository.Create(newToken);
				}
                return MapToDto(result);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }


        // za listu
        /*public Result<PagedResult<CheckpointDto>> GetPagedByTour(int page, int pageSize, int id)
		{
			try
			{
				return MapToDto(_checkpointRepository.GetPagedByTour(page, pageSize, id));
			}
			catch (KeyNotFoundException e)
			{
				return Result.Fail(FailureCode.NotFound).WithError(e.Message);
			}
		}*/

    }
}
