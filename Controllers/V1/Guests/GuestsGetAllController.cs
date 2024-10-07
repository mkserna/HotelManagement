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
    public class GuestsGetAllController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsGetAllController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Retrieves all guests.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to get a list of all guests in the system.
        /// </remarks>
        /// <returns>A list of guests.</returns>
        /// <response code="200">Returns a list of all guests.</response>
        /// <response code="404">Not found if no guests exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all guests", Description = "Retrieves a list of all guests in the system.")]
        [SwaggerResponse(200, "Success: List of guests", typeof(IEnumerable<Guest>))]
        [SwaggerResponse(404, "Not found: No guests exist")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
        {
            var guests = await _guestRepository.GetAll();
            return Ok(guests);
        }
    }
}
