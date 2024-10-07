using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.V1.Booking;
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController(IBookingRepository bookingRepository) : ControllerBase
    {
        protected readonly IBookingRepository _bookingRepository = bookingRepository;
    }
