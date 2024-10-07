using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("guests")]
    public class GuestsDeleteController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsDeleteController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Deletes a guest by ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to delete a specific guest from the system using their unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the guest to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">No content if the deletion is successful.</response>
        /// <response code="404">Not found if the guest with the specified ID does not exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("delete/{id}")]
        [SwaggerOperation(Summary = "Delete a guest", Description = "Deletes a guest from the system by their unique ID.")]
        [SwaggerResponse(204, "No content: Deletion successful")]
        [SwaggerResponse(404, "Not found: Guest with the specified ID does not exist")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> Delete(int id)
        {
            var guestExists = await _guestRepository.CheckExistence(id);
            if (!guestExists)
            {
                return NotFound();
            }

            await _guestRepository.Delete(id);
            return NoContent();
        }
    }
}
