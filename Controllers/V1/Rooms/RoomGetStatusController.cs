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
    public class RoomGetStatusController : RoomController
    {
        private readonly IRoomRepository _roomRepository;

        public RoomGetStatusController(IRoomRepository roomRepository) : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Retrieves a summary of the room statuses.
        /// </summary>
        /// <remarks>
        /// This endpoint provides a summary of all rooms, including the total number of rooms, how many are occupied, and how many are available.
        /// </remarks>
        /// <returns>A summary object with room statuses.</returns>
        /// <response code="200">Returns a summary of room statuses (occupied and available rooms).</response>
        /// <response code="404">No rooms found in the system.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("status")]
        [SwaggerOperation(Summary = "Get room status summary", Description = "Provides a summary of room statuses including total rooms, occupied rooms, and available rooms.")]
        [SwaggerResponse(200, "Success: Room status summary returned", typeof(object))]
        [SwaggerResponse(404, "No rooms found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomStatus()
        {
            var rooms = await _roomRepository.GetAllRoomsAsync();

            if (rooms == null || !rooms.Any())
            {
                return NotFound("No rooms found.");
            }

            var occupiedRooms = rooms.Count(r => r.Availability);
            var availableRooms = rooms.Count(r => !r.Availability);

            var statusSummary = new
            {
                TotalRooms = rooms.Count(),
                OccupiedRooms = occupiedRooms,
                AvailableRooms = availableRooms
            };

            return Ok(statusSummary);
        }
    }
}
