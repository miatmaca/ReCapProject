using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userservice;

        public UsersController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userservice.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserid")]
        public IActionResult GetUserById(int id)
        {
            var result = _userservice.GetUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getemailbyid")]
        public IActionResult GetEmailById(string email)
        {
            var result = _userservice.GetEmailById(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userservice.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userservice.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(UserForRegisterDto user)
        {
            var result = _userservice.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getuserclaimbyid")]
        public IActionResult GetUserClaimById(int userId)
        {
            var result = _userservice.GetClaimUserById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalluserclaim")]
        public IActionResult GetAllUserClaim()
        {
            var result = _userservice.GetAllUserClaim();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getalluserclaimdto")]
        public IActionResult GetAllUserClaimDto()
        {
            var result = _userservice.GetAllUserClaimDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
