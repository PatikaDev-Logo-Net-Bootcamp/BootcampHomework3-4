using BootcampHomework3_4.Business.Abstract;
using BootcampHomework3_4.Business.DTOs;
using BootcampHomework3_4.Domain.Entities;
using BootcampHomework3_4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BootcampHomework3_4.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/authenticate")]
        public IActionResult Authenticate(UserViewModel model)
        {
            var token = _jwtService.Authenticate(
                new JwtUserDTO
                {
                    UserName = model.UserName,
                    UserPassword = model.UserPassword
                });

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [HttpGet]
        [Route("/Users")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("/User")]
        public IActionResult AddUser([FromBody] UserDTO model)
        {
            _userService.AddUser(new User
            {
                UserName = model.UserName,
                UserSurname = model.UserSurname,
                UserGender = model.UserGender,
                UserAge = model.UserAge,
                Password = model.UserPassword,
                CompanyID = model.CompanyID
            });
            return Ok(new BaseResponseModel
            {
                Data = "Added successfully.",
                Success = true
            });
        }

        [HttpDelete]
        [Route("/User/{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Ok(new BaseResponseModel
                {
                    Data = "Deleted successfully.",
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new BaseResponseModel
                {
                    Data = "",
                    Success = false,
                    Error = ex.Message
                });
            }
        }



    }
}
