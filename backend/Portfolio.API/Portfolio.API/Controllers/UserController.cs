using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO.Contact;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.DTO.User;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServ;
        private readonly IContactService _contactServ;

        public UserController(IUserService userServ, IContactService contactServ)
        {
            _userServ = userServ;
            _contactServ = contactServ;
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> GetAll()
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
    }
}
