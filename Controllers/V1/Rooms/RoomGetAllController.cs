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
    public class RoomGetAllController : RoomController
    {
        private readonly IRoomRepository _roomRepository;

        public RoomGetAllController(IRoomRepository roomRepository) : base(roomRepository)
        {
            _roomRepository = roomRepository;
        }

        /// <summary>
        /// Retrieves all available rooms.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all the rooms in the system, including their details like room type, capacity, and nightly rate.
        /// </remarks>
        /// <returns>A list of rooms.</returns>
        /// <response code="200">Returns the list of rooms.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all rooms", Description = "Fetches all the rooms in the system.")]
        [SwaggerResponse(200, "Success: Room list returned successfully", typeof(IEnumerable<Room>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<Room>>> GetAll()
        {
            var products = await _roomRepository.GetAll();
            return Ok(products);
        }
    }
}
