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
    public class GuestsGetByIdController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsGetByIdController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Retrieves a guest by ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to get a specific guest from the system using their unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the guest to retrieve.</param>
        /// <returns>The guest details.</returns>
        /// <response code="200">Returns the details of the guest.</response>
        /// <response code="404">Not found if the guest with the specified ID does not exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("search/{id}")]
        [SwaggerOperation(Summary = "Get guest by ID", Description = "Retrieves a specific guest from the system by their unique ID.")]
        [SwaggerResponse(200, "Success: Guest details", typeof(Guest))]
        [SwaggerResponse(404, "Not found: Guest with the specified ID does not exist")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Guest>> GetById(int id)
        {
            var guest = await _guestRepository.GetById(id);
            if (guest == null)
            {
                return NotFound();
            }
            return guest;
        }
    }
}
