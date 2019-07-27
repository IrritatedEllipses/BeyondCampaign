using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BeyondCampaign.API.Data;
using BeyondCampaign.API.Dtos;
using BeyondCampaign.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BeyondCampaign.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUsersRepository _usersRepository;
        private readonly IAuthRepository _authRepository;

        public AuthController(IUsersRepository usersRepository, IAuthRepository authRepository,
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usersRepository = usersRepository;
            _authRepository = authRepository;
        }

        [HttpGet("isUserNameAvailable/{username}")]
        public async Task<IActionResult> IsUserNameAvailable(string username)
        {
            var result = await _usersRepository.IsUserNameAvailable(username);

            if (!result)
            {
                return Ok();
            }
            return BadRequest("Username or Password error");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _authRepository.Register(userForRegisterDto);

            if (result.Id > 0)
            {
                return Ok(userForRegisterDto);
            }

            return BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);

            var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = _authRepository.GenerateJWT(user)
                });
            }

            return Unauthorized();

        }

        
    }
}