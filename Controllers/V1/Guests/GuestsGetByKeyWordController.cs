using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("guests")]
    public class GuestsGetByKeyWordController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsGetByKeyWordController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Searches for guests by keyword.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to search for guests based on a provided keyword, 
        /// which can be part of the guest's name or other attributes.
        /// </remarks>
        /// <param name="keyword">The keyword to search for.</param>
        /// <returns>A list of guests matching the keyword.</returns>
        /// <response code="200">Returns a list of guests matching the keyword.</response>
        /// <response code="400">Bad request if the keyword is empty.</response>
        /// <response code="404">Not found if no guests match the provided keyword.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("search/{keyword}")]
        [SwaggerOperation(Summary = "Search guests by keyword", Description = "Retrieves a list of guests based on a provided keyword.")]
        [SwaggerResponse(200, "Success: List of guests matching the keyword", typeof(IEnumerable<Guest>))]
        [SwaggerResponse(400, "Bad request: The keyword cannot be empty.")]
        [SwaggerResponse(404, "Not found: No guests found with the provided keyword.")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<Guest>>> SearchByKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("The keyword cannot be empty.");
            }

            var guests = await _guestRepository.GetByKeyword(keyword);

            if (!guests.Any())
            {
                return NotFound("No guests found with the provided keyword.");
            }

            return Ok(guests);
        }
    }
}
