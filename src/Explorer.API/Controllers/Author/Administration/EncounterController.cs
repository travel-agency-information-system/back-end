using Explorer.API.Services;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain.BlogPosts;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain.Encounters;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public.Administration;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.UseCases.Administration;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using static System.Net.Mime.MediaTypeNames;

namespace Explorer.API.Controllers.Author.Administration
{
    [Route("api/administration/encounter")]

    public class EncounterController : BaseApiController
    {
        private readonly IEncounterService _encounterService;
        private readonly ImageService _imageService;


        public EncounterController(IEncounterService encounterService)
        {
            _encounterService = encounterService;
            _imageService = new ImageService();

        }


        [HttpPost]
        [Authorize(Policy = "authorPolicy")]
        public ActionResult<EncounterDto> Create([FromForm] EncounterDto encounter,[FromQuery] long checkpointId, [FromQuery] bool isSecretPrerequisite, [FromForm] List<IFormFile>? image = null)
        {

            if (image != null && image.Any())
            {
                var imageNames = _imageService.UploadImages(image);
                if (encounter.HiddenLocationEncounter !=null)
                    encounter.HiddenLocationEncounter.Image = imageNames[0];
            }

            var result = _encounterService.Create(encounter, checkpointId, isSecretPrerequisite,User.PersonId());
            return CreateResponse(result);
        }

        [HttpPut("add/{encounterId:int}/{touristId:int}")]
        public ActionResult<EncounterDto> FinishEncounter(int encounterId, int touristId)
        {
            var result = _encounterService.FinishEncounter(encounterId, touristId);
            return CreateResponse(result);
        }
    }
}
