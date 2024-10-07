using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingDeleteController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingDeleteController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Deletes a booking by its ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the deletion of an existing booking. If the booking does not exist, it returns a 404 status code.
        /// </remarks>
        /// <param name="id">The unique ID of the booking to be deleted.</param>
        /// <returns>No content if the deletion is successful.</returns>
        /// <response code="204">Booking deleted successfully.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a booking by ID", Description = "Deletes a booking by its unique ID.")]
        [SwaggerResponse(204, "Success: Booking deleted")]
        [SwaggerResponse(404, "Booking not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> Delete(int id)
        {
            var bookingExists = await _bookingRepository.CheckExistence(id);
            if (!bookingExists)
            {
                return NotFound();
            }

            await _bookingRepository.Delete(id);
            return NoContent();
        }
    }
}
