using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController(IGuestRepository guestRepository) : ControllerBase
    {
        protected readonly IGuestRepository _guestRepository = guestRepository;
    }
}