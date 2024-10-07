using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers.V1.Rooms
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController(IRoomRepository roomRepository) : ControllerBase
    {
        protected readonly IRoomRepository _roomRepository = roomRepository;
    }
}