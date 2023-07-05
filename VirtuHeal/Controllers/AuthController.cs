using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtuHeal.Data;
using VirtuHeal.DTOs;
using VirtuHeal.Models;
using VirtuHeal.Services;

namespace VirtuHeal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public AuthController(IUserService userService, IPasswordService passwordService, IJwtService jwtService)
        {
            _userService = userService;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }



        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterDto request)
        {
            var db_response = await _userService.CheckUser(request.Username);

            if (db_response.Data == null)
            {
                // Create a password hash and salt
                _passwordService.CreatePasswordHash(request.Password, out byte[] PasswordHash, out byte[] passwordSalt);

                //Register a user
                var response = await _userService.RegisterUser(request.Username, PasswordHash, passwordSalt, request.Role);

                // Get all student information


                return Ok(response.Data);
            }
            else
            {
                return NotFound(new { db_response.Error });
            }
        }


        [HttpPost("registerstudent")]
        public async Task<ActionResult<User>> RegisterStudent(StudentInfoDto request)
        {
            var response = await _userService.StudentUser(request);

            if (response.Data == null)
            {
                return NotFound(new { response.Error });
            }
            return Ok(response.Data);
        }

        [HttpPost("registerpsychiatrist")]
        public async Task<ActionResult<User>> RegisterPsychiatrist(PsychiatristInfoDto request)
        {
            var response = await _userService.PsychiatristUser(request);

            if (response.Data == null)
            {
                return NotFound(new { response.Error });
            }
            return Ok(response.Data);
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            var response = await _userService.LoginUser(request);
            if (response.Data == null)
            {
                return NotFound(new { response.Error });
            }

            var passwordResponse = _passwordService.VerifyPasswordHash(request.Password, response.Data.password_hash, response.Data.password_salt);
            if (!passwordResponse.Data)
            {
                return NotFound(new { passwordResponse.Error });
            }

            string jwt = _jwtService.CreateToken(response.Data);
            return Ok(new { jwt, response.Data });
        }
    }
}
