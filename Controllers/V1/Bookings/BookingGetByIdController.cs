using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingGetByIdController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetByIdController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Retrieves a booking by its ID.
        /// </summary>
        /// <remarks>
        /// This endpoint returns the details of a specific booking identified by its unique ID.
        /// </remarks>
        /// <param name="id">The unique ID of the booking to retrieve.</param>
        /// <returns>The requested booking.</returns>
        /// <response code="200">Returns the details of the requested booking.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a booking by ID", Description = "Retrieves the details of a booking by its unique ID.")]
        [SwaggerResponse(200, "Success: Booking details returned", typeof(Models.Booking))]
        [SwaggerResponse(404, "Booking not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Models.Booking>> GetById(int id)
        {
            var booking = await _bookingRepository.GetById(id);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }
    }
}
