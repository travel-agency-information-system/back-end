using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.Core.Mappers;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain.Encounters;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System.Data;

namespace Explorer.Encounters.Core.UseCases
{
    public class EncounterService : CrudService<EncounterDto, Encounter>, IEncounterService
    {
        private readonly IEncounterRepository _encounterRepository;
        private readonly IInternalCheckpointService _internalCheckpointService;
        private readonly IInternalCustomerService _internalCustomerService;
        public EncounterService(IEncounterRepository encounterRepository,IInternalCheckpointService internalCheckpointService, IInternalCustomerService internalCustomerService, IMapper mapper) : base(encounterRepository, mapper)
        {
            _encounterRepository= encounterRepository;
            _internalCheckpointService= internalCheckpointService;
            _internalCustomerService= internalCustomerService;
        }

        public Result<EncounterDto> Create(EncounterDto encounterDto,long checkpointId,bool isSecretPrerequisite,long userId)
        {
            Encounter encounter = MapToDomain(encounterDto);
            Encounter result;
            if (!encounter.IsAuthor(userId)) 
                return Result.Fail(FailureCode.Forbidden); 

            try
            {
                result = _encounterRepository.Create(encounter);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }

            try
            {
                _internalCheckpointService.SetEncounter((int)checkpointId, result.Id, isSecretPrerequisite, (int)result.AuthorId);
            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
            catch (ArgumentException e)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(e.Message);
            }
            return MapToDto(result);
        }

        public Result<EncounterDto> FinishEncounter(int encounterId, int touristId)
        {
            Encounter encounter = _encounterRepository.Get(encounterId);

            if (encounter == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Encounter not found.");
            }


            _internalCustomerService.AddXpToCustomer(touristId, encounter.XP);
            CompletedEncounter completedEncounter = new CompletedEncounter(touristId, DateTime.Now);
            encounter.FinishEncounter(completedEncounter);
            var result = _encounterRepository.Update(encounter);
            return MapToDto(result);
        }

        
    }
}
