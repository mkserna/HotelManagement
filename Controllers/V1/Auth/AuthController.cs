using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelManagement.Config;
using HotelManagement.Data;
using HotelManagement.Models;
using HotelManagement.Models.DTOs;
using HotelManagement.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelManagement.Controllers.V1.Auth
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtConfig _utilities;

        public AuthController(ApplicationDbContext context, JwtConfig utilities)
        {
            _context = context;
            _utilities = utilities;
        }

        /// <summary>
        /// Registers a new guest.
        /// </summary>
        /// <param name="newGuest">The guest information to register.</param>
        /// <returns>A success message if registration is successful, or an error message.</returns>
        /// <response code="200">User registered successfully.</response>
        /// <response code="400">Bad request, including validation errors.</response>
        [HttpPost("register")]
        [SwaggerOperation(Summary = "Register a new guest", Description = "Creates a new guest account.")]
        [SwaggerResponse(200, "User registered successfully")]
        [SwaggerResponse(400, "Bad request, including validation errors")]
        public async Task<IActionResult> Register(GuestDTO newGuest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Guests.Any(u => u.Email == newGuest.Email))
            {
                return BadRequest("Email already exists");
            }

            var guest = new Guest
            {
                FirstName = newGuest.FirstName,
                LastName = newGuest.LastName,
                Email = newGuest.Email,
                PhoneNumber = newGuest.PhoneNumber,
                BirthDate = newGuest.BirthDate,
            };

            // Agregar la entidad al contexto
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }

        /// <summary>
        /// Authenticates a guest and generates a JWT token.
        /// </summary>
        /// <param name="request">The login request containing the email and password.</param>
        /// <returns>A JWT token if authentication is successful, or an error message.</returns>
        /// <response code="200">Returns a JWT token for the authenticated user.</response>
        /// <response code="401">Unauthorized, invalid credentials.</response>
        /// <response code="400">Bad request, including validation errors.</response>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Login guest", Description = "Authenticates a guest and generates a JWT token.")]
        [SwaggerResponse(200, "JWT token returned successfully")]
        [SwaggerResponse(401, "Invalid email or password")]
        [SwaggerResponse(400, "Bad request, including validation errors")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (employee == null)
            {
                return Unauthorized("Invalid email");
            }

            var passwordIsValid = employee.Password == _utilities.EncryptSHA256(request.Password);

            if (!passwordIsValid)
            {
                return Unauthorized("Invalid password");
            }

            var token = _utilities.GenerateJwtToken(employee);
            return Ok(new
            {
                message = "Please, save this token",
                jwt = token
            });
        }
    }
}
