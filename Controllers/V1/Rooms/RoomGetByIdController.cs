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
    public class RoomGetByIdController : RoomController
    {
        private readonly IRoomRepository _roomRepository;

        public RoomGetByIdController(IRoomRepository roomRepository) : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Retrieves a room by its ID.
        /// </summary>
        /// <remarks>
        /// This endpoint allows you to search for a room by its unique identifier (ID).
        /// If the room does not exist, it returns a 404 status code.
        /// </remarks>
        /// <param name="id">The unique ID of the room.</param>
        /// <returns>A room object.</returns>
        /// <response code="200">Returns the room with the specified ID.</response>
        /// <response code="404">Room not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("search/{id}")]
        [SwaggerOperation(Summary = "Get room by ID", Description = "Retrieves a room by its unique ID.")]
        [SwaggerResponse(200, "Success: Room returned", typeof(Room))]
        [SwaggerResponse(404, "Room not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<Room>> GetById(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
            {
                return NotFound("Room not found.");
            }
            return Ok(room);
        }
    }
}
