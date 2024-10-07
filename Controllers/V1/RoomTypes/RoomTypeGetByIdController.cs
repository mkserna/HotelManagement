using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.RoomTypes
{
    [ApiController]
    [Route("api/v1/roomtypes")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("roomtypes")]
    public class RoomTypeGetByIdController : RoomTypeController
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeGetByIdController(IRoomTypeRepository roomTypeRepository) : base(roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        /// <summary>
        /// Retrieves a room type by its ID.
        /// </summary>
        /// <param name="id">The ID of the room type to retrieve.</param>
        /// <returns>The room type if found; otherwise, a 404 Not Found response.</returns>
        /// <response code="200">Returns the room type.</response>
        /// <response code="404">Room type not found.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get room type by ID", Description = "Fetches a specific room type by its ID.")]
        [SwaggerResponse(200, "Success: Room type returned successfully", typeof(RoomType))]
        [SwaggerResponse(404, "Room type not found")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<RoomType>> GetById(int id)
        {
            var roomType = await _roomTypeRepository.GetById(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return roomType;
        }
    }
}
