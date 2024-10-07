using HotelManagement.Models;
using HotelManagement.Models.DTOs;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("guests")]
    public class GuestsCreateController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsCreateController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Creates a new guest.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to add a new guest to the system.
        /// </remarks>
        /// <param name="inputGuest">The details of the guest to create.</param>
        /// <returns>The newly created guest.</returns>
        /// <response code="200">Returns the details of the newly created guest.</response>
        /// <response code="400">Bad request if the model state is invalid.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new guest", Description = "Adds a new guest to the system.")]
        [SwaggerResponse(200, "Success: Guest created", typeof(Guest))]
        [SwaggerResponse(400, "Bad request: Invalid model state")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Guest>> Create(GuestDTO inputGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGuest = new Guest
            {
                FirstName = inputGuest.FirstName,
                LastName = inputGuest.LastName,
                Email = inputGuest.Email,
                PhoneNumber = inputGuest.PhoneNumber,
                BirthDate = inputGuest.BirthDate
            };

            await _guestRepository.Add(newGuest);
            return Ok(newGuest);
        }
    }
}
