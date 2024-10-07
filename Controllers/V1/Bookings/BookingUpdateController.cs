using HotelManagement.Models.DTOs;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingUpdateController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingUpdateController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Updates the details of a booking.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to update the details of a specific booking identified by its unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the booking to update.</param>
        /// <param name="updatedProduct">The updated booking details.</param>
        /// <returns>No content if the update is successful.</returns>
        /// <response code="204">No content if the update is successful.</response>
        /// <response code="400">Bad request if the model state is invalid.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a booking", Description = "Updates the details of a booking by its unique ID.")]
        [SwaggerResponse(204, "No content: Update successful")]
        [SwaggerResponse(400, "Bad request: Invalid model state")]
        [SwaggerResponse(404, "Booking not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> Update(int id, BookingDTO updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var checkBooking = await _bookingRepository.CheckExistence(id);
            if (!checkBooking)
            {
                return NotFound();
            }

            var booking = await _bookingRepository.GetById(id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.StartDate = updatedProduct.StartDate;
            booking.EndDate = updatedProduct.EndDate;
            booking.TotalCost = updatedProduct.TotalCost;
            booking.RoomId = updatedProduct.RoomId;
            booking.GuestId = updatedProduct.GuestId;
            booking.EmployeeId = updatedProduct.EmployeeId;

            await _bookingRepository.Update(booking);
            return NoContent();
        }
    }
}
