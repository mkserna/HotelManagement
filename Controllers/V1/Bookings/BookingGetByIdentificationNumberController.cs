using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Booking
{
    [ApiController]
    [Route("api/v1/booking")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("booking")]
    public class BookingGetByIdentificationNumberController : BookingController
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingGetByIdentificationNumberController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Retrieves a booking by the identification number.
        /// </summary>
        /// <remarks>
        /// This endpoint returns the details of a specific booking identified by the customer's identification number.
        /// </remarks>
        /// <param name="identificationNumber">The unique identification number of the customer.</param>
        /// <returns>The requested booking.</returns>
        /// <response code="200">Returns the details of the requested booking.</response>
        /// <response code="404">Booking not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("identification/{identificationNumber}")]
        [SwaggerOperation(Summary = "Get a booking by identification number", Description = "Retrieves the details of a booking by the customer's identification number.")]
        [SwaggerResponse(200, "Success: Booking details returned", typeof(Models.Booking))]
        [SwaggerResponse(404, "Booking not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Models.Booking>> GetByIdentificationNumber(string identificationNumber)
        {
            var booking = await _bookingRepository.GetByIdentificationNumber(identificationNumber);
            if (booking == null)
            {
                return NotFound();
            }
            return booking;
        }
    }
}
