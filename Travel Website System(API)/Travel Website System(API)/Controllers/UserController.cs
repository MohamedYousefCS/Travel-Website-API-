﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Travel_Website_System_API.Models;
using Travel_Website_System_API_.Repositories;

namespace Travel_Website_System_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserRepo _userRepo;

        public UserController(UserManager<ApplicationUser> userManager, UserRepo userRepo)
        {
            _userManager = userManager;
            _userRepo = userRepo;
        }

        [HttpGet("All")]
        [Authorize(Roles = "superAdmin, admin")]
        public ActionResult<IEnumerable<ApplicationUser>> GetUsers()
        {
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            if (roles.Contains("superAdmin"))
            {
                var allUsers = _userRepo.GetAll();
                return Ok(allUsers);
            }
            else if(roles.Contains("admin"))
            {
                var adminId = User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (adminId != null)
                {
                    var clients = _userRepo.GetClientsByAdminId(adminId);
                    return Ok(clients);
                }
            }
            return NotFound();

        }


        [HttpGet("admins")]
        [Authorize(Roles = "superAdmin")]
        public ActionResult<IEnumerable<Admin>> GetAdmins()
        {
            var admins = _userRepo.GetAllAdmins();
            if (admins == null || !admins.Any())
            {
                return NotFound(new { message = "No admins found" });
            }
            return Ok(admins);
        }


        [HttpGet("clients")]
        [Authorize(Roles = "superAdmin, admin")]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var roles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

            if (roles.Contains("superAdmin"))
            {
                var allClients = _userRepo.GetAllClients().Where(c=>c.IsDeleted==false);
                return Ok(allClients);
            }
            else if (roles.Contains("admin"))
            {
                var adminId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                if (adminId != null)
                {
                    var clients = _userRepo.GetClientsByAdminId(adminId);
                    if (clients == null || !clients.Any())
                    {
                        return NotFound(new { message = "No clients found for this admin" });
                    }
                    return Ok(clients);
                }
            }

            return Unauthorized(new { message = "Unauthorized access" });
        }




        [HttpGet("customerService")]
        [Authorize(Roles = "superAdmin")]
        public ActionResult<IEnumerable<Admin>> GetCustomerServices()
        {
            var cus = _userRepo.GetAllcustomerServices();
            if (cus == null || !cus.Any())
            {
                return NotFound(new { message = "No customer services found" });
            }
            return Ok(cus);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUserDetails(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            user.Fname = updatedUser.Fname;
            user.Lname = updatedUser.Lname;
            user.Gender = updatedUser.Gender;
            user.SSN = updatedUser.SSN;
            user.Role = updatedUser.Role;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || user.IsDeleted)
            {
                return NotFound();
            }

            user.IsDeleted = true;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }
            return Ok(new { message = "user deleted successfully" });
          
        }


    }
}
