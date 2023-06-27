﻿using API.PresentationLayer.DTOModels;
using Logic.ServiceLayer.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService) { _userService = userService; }

        [HttpGet(Name = "GetUser")]
        public async Task<ActionResult<UserDTO>>  GetUserAsync(int id)
        {
            UserDTO userDTO;
            var user = await _userService.GetAsync(id);

            if(user == null)
                return NotFound();

            // Map user to UserDTO
            userDTO = new UserDTO { Email = user.Email };

            return Ok(userDTO);
        }
    }
}
