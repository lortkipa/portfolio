using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.Contact;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.DTO.User;
using Portfolio.Service.Helpers;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServ;
        private readonly IContactService _contactServ;
        private readonly IConfiguration _config;
        public UserController(IUserService userServ, IContactService contactServ, IConfiguration config)
        {
            _userServ = userServ;
            _contactServ = contactServ;
            _config = config;
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userServ.GetByIdAsync(1);
            var contact = await _contactServ.GetByIdAsync(user.ContactId);

            var result = new UserProfileDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Contact = new ContactDTO
                {
                    Id  = contact.Id,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Location = contact.Location,
                    GithubLink = contact.GithubLink,
                    LinkedinLink = contact.LinkedinLink,
                }
            };

            return Ok(result);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponseDTO>> Login(LoginUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userServ.LoginAsync(model);
                if (result.Status)
                {
                    var user = await _userServ.GetByEmailAsync(model.Email);

                    var token = TokenHelper.GenerateToken(user.Id, model.Email, _config);

                    HttpContext.Response.Cookies.Append("Token", token);

                    return Ok(new AuthResponseDTO { Status = true, Message = token });
                }

                return Unauthorized(result.Message);
            }

            return BadRequest();
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<ActionResult<AuthResponseDTO>> Logout(string token)
        {
            HttpContext.Response.Cookies.Delete("Token");

            return new AuthResponseDTO
            {
                Status = true,
                Message = "Logged out successfully"
            };
        }
        [Authorize]
        [HttpPut("UpdateProfileContact/{contactId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> UpdateProfileContact(int contactId, UpdateContactDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
                                            {
                                                Status = false,
                                                Message = "Invalid Request Data"
                                            });

            var contact = await _contactServ.GetByIdAsync(contactId);
            if (contact == null) return NotFound(new AuthResponseDTO
                                        {
                                            Status = false,
                                            Message = "Contact not found."
                                        });

            var result = await _contactServ.UpdateAsync(contactId, model);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Contact updated successfully."
                });
            }

            return Ok(new AuthResponseDTO
            {
                Status = true,
                Message = "Failed To Update Contact."
            });
        }
    }
}
