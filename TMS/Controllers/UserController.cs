using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TMS.Contracts;
using TMS.Data.Models;

namespace TMS.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public IConfiguration _config;
        public UserController(IUnitOfWork uow, IConfiguration config)
        {
            _uow = uow;
            _config = config;
        }
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return _uow.UserRepository.Get()
                .OrderByDescending(x => x.UserId)
                .Where(x => x.DelStatus == "N");
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _uow.UserRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/User/Authenticate

        [AllowAnonymous]
        [Route("Authenticate")]
        [HttpPost]
        public ActionResult<UserViewModel> Authenticate(UserViewModel userCredentials)
        {
            var user = _uow.UserRepository.GetUserByUserNamePassword(userCredentials.UserName, userCredentials.Password);

            if (user == null)
            {
                return NotFound();
            }
            string token = CreateToken(user);
            userCredentials.UserId = user.UserId;
            userCredentials.FullName = user.FullName;
            userCredentials.Token = token;
            return userCredentials;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                _uow.UserRepository.Update(user);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Updated Sucessfully");
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            _uow.UserRepository.Add(user);
            _uow.Commit();
            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            try
            {
                _uow.UserRepository.Update(user);
                _uow.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Deleted Sucessfully");
            //var user = _uow.UserRepository.GetById(id);
            //if (user == null)
            //{
            //    return NotFound();
            //}

            //_uow.UserRepository.Delete(user);
            //_uow.Commit();
            //return user;
        }

        private bool UserExists(int id)
        {
            var user = _uow.UserRepository.GetById(id);
            if (user == null)
            {
                return false;
            }
            return true;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }

    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
    }
}
