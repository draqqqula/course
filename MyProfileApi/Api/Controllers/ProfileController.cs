using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Services.Interfaces;

namespace Api.Controllers
{
    public record CreateProfileRequest
    {
        public required string Name {  get; init; }
        public required string Description { get; init; }
    }

    public record GetProfileResponse
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required int Reputation { get; init; }
        public required uint AskedCount { get; init; }
        public required uint AnsweredCount { get; init; }
        public required uint SolvedCount { get; init; }
    }

    public record CreateProfileResponse
    {
        public required Guid Id { get; init; }
    }

    public record IncreaceCounterRequest
    {
        public required Guid Id { get; init; }
        public required int Amount { get; init; }
    }

    public record IncreaceCounterResponse
    {
        public required Guid? Id { get; init ; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ICreateProfile _createProfile;
        private readonly IGetProfile _getProfile;
        public ProfileController(ICreateProfile createProfile, IGetProfile getProfile) 
        { 
            _createProfile = createProfile;
            _getProfile = getProfile;
        }

        [HttpPost]
        [Route("new")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateProfileAsync([FromBody] CreateProfileRequest request)
        {
            var id = await _createProfile.CreateProfileAsync(new Profile
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            });
            return Ok(new CreateProfileResponse()
            {
                Id = id
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetProfileResponse), 200)]
        public async Task<IActionResult> GetInfoAsync([FromQuery] Guid profileId)
        {
            var profile = await _getProfile.GetProfileAsync(profileId);
            if (profile is null)
            {
                return NotFound();
            }
            return Ok(new GetProfileResponse
            {
                Name = profile.Name,
                Description = profile.Description,
                Reputation = profile.Reputation,
                AnsweredCount = profile.AnsweredCount,
                AskedCount = profile.AskedCount,
                SolvedCount = profile.SolvedCount,
            });
        }


        [HttpPut]
        [Route("asked")]
        public async Task<IActionResult> IncreaceAskedCounterAsync(
            [FromBody]IncreaceCounterRequest request, 
            [FromKeyedServices("asked")]IIncreaceCounter increace)
        {
            var id = await increace.IncreaceCounterAsync(request.Id, request.Amount);
            return Ok(new IncreaceCounterResponse()
            {
                Id= id,
            });
        }

        [HttpPut]
        [Route("answered")]
        public async Task<IActionResult> IncreaceAnsweredCounterAsync(
        [FromBody] IncreaceCounterRequest request,
        [FromKeyedServices("answered")] IIncreaceCounter increace)
        {
            var id = await increace.IncreaceCounterAsync(request.Id, request.Amount);
            return Ok(new IncreaceCounterResponse()
            {
                Id = id,
            });
        }

        [HttpPut]
        [Route("solved")]
        public async Task<IActionResult> IncreaceSolvedCounterAsync(
        [FromBody] IncreaceCounterRequest request,
        [FromKeyedServices("solved")] IIncreaceCounter increace)
        {
            var id = await increace.IncreaceCounterAsync(request.Id, request.Amount);
            return Ok(new IncreaceCounterResponse()
            {
                Id = id,
            });
        }
    }
}
