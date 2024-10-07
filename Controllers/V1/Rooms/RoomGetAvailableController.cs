using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("rooms")]
    public class RoomGetAvailableController : RoomController
    {
        private readonly IRoomRepository _roomRepository;

        public RoomGetAvailableController(IRoomRepository roomRepository) : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Retrieves the first available room.
        /// </summary>
        /// <remarks>
        /// This endpoint checks the system and returns the first available room. 
        /// If no rooms are available, it returns a 404 status code.
        /// </remarks>
        /// <returns>An available room.</returns>
        /// <response code="200">Returns the first available room.</response>
        /// <response code="404">No available rooms found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("available")]
        [SwaggerOperation(Summary = "Get an available room", Description = "Retrieves the first available room in the system.")]
        [SwaggerResponse(200, "Success: Available room returned", typeof(Room))]
        [SwaggerResponse(404, "No available rooms found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Room>> GetAvailableRoom()
        {
            var availableRoom = await _roomRepository.GetAvailable();

            if (availableRoom == null)
            {
                return NotFound("No available rooms found.");
            }

            return Ok(availableRoom);
        }
    }
}
