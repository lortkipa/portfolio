using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.About;
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
        private readonly IAboutService _aboutServ;
        private readonly IEmailJSService _emailServ;
        private readonly IConfiguration _config;
        public UserController(IAboutService aboutServ, IUserService userServ, IContactService contactServ, IEmailJSService emailServ, IConfiguration config)
        {
            _aboutServ = aboutServ;
            _userServ = userServ;
            _contactServ = contactServ;
            _emailServ = emailServ;
            _config = config;
        }

        [HttpGet("Profile")]
        public async Task<ActionResult<UserProfileDTO>> Profile()
        {
            var user = await _userServ.GetByIdAsync(1);
            var contact = await _contactServ.GetByIdAsync(user.ContactId);
            var email = await _emailServ.GetByIdAsync(contact.EmailJSId);
            var about = await _aboutServ.GetByIdAsync(user.AboutId);

            var result = new UserProfileDTO
            {
                Id = user.Id,
                Contact = new ContactWithEmailJSDTO
                {
                    Id = contact.Id,
                    EmailJS = email,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Location = contact.Location,
                    GithubLink = contact.GithubLink,
                    LinkedinLink = contact.LinkedinLink,
                },
                About = new AboutDTO
                {
                    Id = about.Id,
                    FullName = about.FullName,
                    JobTitle = about.JobTitle,
                    Bio = about.Bio,
                    StatusBadge = about.StatusBadge,
                    FunBadge = about.FunBadge
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
        public async Task<ActionResult<AuthResponseDTO>> UpdateProfileContact(int contactId, UpdateContactWithEmailJSDTO model)
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

            var result = await _emailServ.UpdateAsync(contact.EmailJSId, model.EmailJS);

            var contactModel = new UpdateContactDTO
            {
                EmailJSId = contact.EmailJSId,
                Email = model.Email,
                Location = model.Location,
                PhoneNumber = model.PhoneNumber,
                GithubLink = model.GithubLink,
                LinkedinLink = model.LinkedinLink
            };
            result = await _contactServ.UpdateAsync(contactId, contactModel);
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
        [Authorize]
        [HttpPut("UpdateProfileAbout/{aboutId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> UpdateProfileAbout(int aboutId, UpdateAboutDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Invalid Request Data"
            });

            var contact = await _aboutServ.GetByIdAsync(aboutId);
            if (contact == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "About info not found."
            });

            var result = await _aboutServ.UpdateAsync(aboutId, model);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "About info updated successfully."
                });
            }

            return Ok(new AuthResponseDTO
            {
                Status = true,
                Message = "Failed to update about info."
            });
        }
    }
}
