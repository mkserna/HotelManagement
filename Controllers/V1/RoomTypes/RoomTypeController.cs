using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.V1.RoomTypes
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController(IRoomTypeRepository roomTypeRepository) : ControllerBase
    {
        protected readonly IRoomTypeRepository _roomTypeRepository = roomTypeRepository;
    }
}