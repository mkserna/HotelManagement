using HotelManagement.Repositories;
using HotelManagement.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingCreateController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingCreateController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Creates a new booking.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the creation of a new booking. The booking must include information such as the start date, end date, total cost, room ID, guest ID, and employee ID.
        /// </remarks>
        /// <param name="booking">The details of the booking (BookingDTO).</param>
        /// <returns>The newly created booking.</returns>
        /// <response code="200">Returns the newly created booking.</response>
        /// <response code="400">Invalid data was provided.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new booking", Description = "Creates a new booking with details such as start date, end date, room, guest, and employee information.")]
        [SwaggerResponse(200, "Success: Booking created", typeof(Models.Booking))]
        [SwaggerResponse(400, "Invalid data provided")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Models.Booking>> Create(BookingDTO booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBooking = new Models.Booking
            {
                StartDate = booking.StartDate,
                EndDate = booking.EndDate,
                TotalCost = booking.TotalCost,
                RoomId = booking.RoomId,
                GuestId = booking.GuestId,
                EmployeeId = booking.EmployeeId
            };

            await _bookingRepository.Add(newBooking);
            return Ok(newBooking);
        }
    }
}
