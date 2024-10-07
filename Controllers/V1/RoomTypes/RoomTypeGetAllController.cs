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
    public class RoomTypeGetAllController : RoomTypeController
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeGetAllController(IRoomTypeRepository roomTypeRepository) : base(roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        /// <summary>
        /// Retrieves all room types.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all the room types in the system, including their details like capacity and price per night.
        /// </remarks>
        /// <returns>A list of room types.</returns>
        /// <response code="200">Returns the list of room types.</response>
        /// <response code="500">Internal server error.</response>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all room types", Description = "Fetches all the room types in the system.")]
        [SwaggerResponse(200, "Success: Room type list returned successfully", typeof(IEnumerable<RoomType>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<ActionResult<IEnumerable<RoomType>>> GetAll()
        {
            var roomType = await _roomTypeRepository.GetAll();
            return Ok(roomType);
        }
    }
}
