using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingGetAllController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetAllController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Retrieves a list of all bookings.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all existing bookings in the system.
        /// </remarks>
        /// <returns>A list of bookings.</returns>
        /// <response code="200">Returns a list of all bookings.</response>
        /// <response code="404">No bookings found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all bookings", Description = "Retrieves a list of all bookings in the system.")]
        [SwaggerResponse(200, "Success: List of bookings returned", typeof(IEnumerable<Models.Booking>))]
        [SwaggerResponse(404, "No bookings found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<Models.Booking>>> GetAll()
        {
            var bookings = await _bookingRepository.GetAll();
            if (bookings == null || !bookings.Any())
            {
                return NotFound("No bookings found.");
            }

            return Ok(bookings);
        }
    }
}
