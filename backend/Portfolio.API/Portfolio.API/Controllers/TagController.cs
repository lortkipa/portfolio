using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagServ;

        public TagController(ITagService tagServ)
        {
            _tagServ = tagServ;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<TagDTO>> GetAll()
        {
            var tags = await _tagServ.GetAllAsync();
            return Ok(tags);
        }
    }
}
