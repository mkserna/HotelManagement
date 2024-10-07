using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Models.DTOs;
using HotelManagement.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("guests")]
    public class GuestsUpdateController : GuestsController
    {
        private readonly IGuestRepository _guestRepository;

        public GuestsUpdateController(IGuestRepository guestRepository) : base(guestRepository)
        {
            _guestRepository = guestRepository;
        }

        /// <summary>
        /// Updates guest information.
        /// </summary>
        /// <remarks>
        /// This endpoint allows the user to update an existing guest's details.
        /// </remarks>
        /// <param name="id">The ID of the guest to update.</param>
        /// <param name="updatedProduct">The updated guest data.</param>
        /// <returns>No content if the update is successful.</returns>
        /// <response code="204">No content: Update was successful.</response>
        /// <response code="400">Bad request if the model state is invalid.</response>
        /// <response code="404">Not found if the guest with the specified ID does not exist.</response>
        /// <response code="500">Internal server error.</response>
        [HttpPut("update/{id}")]
        [SwaggerOperation(Summary = "Update guest information", Description = "Updates the details of an existing guest.")]
        [SwaggerResponse(204, "No content: Update was successful.")]
        [SwaggerResponse(400, "Bad request: Model state is invalid.")]
        [SwaggerResponse(404, "Not found: Guest with the specified ID does not exist.")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> Update(int id, GuestDTO updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var checkGuest = await _guestRepository.CheckExistence(id);
            if (!checkGuest)
            {
                return NotFound();
            }

            var guest = await _guestRepository.GetById(id);

            if (guest == null)
            {
                return NotFound();
            }

            guest.FirstName = updatedProduct.FirstName;
            guest.LastName = updatedProduct.LastName;
            guest.Email = updatedProduct.Email;
            guest.PhoneNumber = updatedProduct.PhoneNumber;
            guest.BirthDate = updatedProduct.BirthDate;

            await _guestRepository.Update(guest);
            return NoContent();
        }
    }
}
