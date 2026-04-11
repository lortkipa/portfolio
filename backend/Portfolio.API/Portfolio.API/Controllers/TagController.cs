using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO;
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
        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult<TagDTO>> Add([FromBody] CreateTagDTO model)
        {
            var tag = await _tagServ.CreateAsync(model);
            if (tag == null)
            {
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Failed to create project"
                });
            }

            return Ok(tag);
        }
        [Authorize]
        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<TagDTO>> Update(int id, [FromBody] UpdateTagDTO model)
        {
            var tag = await _tagServ.GetByIdAsync(id);
            if (tag == null)
            {
                return NotFound(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Tag doesn't exist"
                });
            }

            var updatedTag = await _tagServ.UpdateAsync(id, model);
            if (!updatedTag)
            {
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Failed to update tag"
                });
            }

            return Ok(updatedTag);
        }
        [Authorize]
        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult<AuthResponseDTO>> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Invalid request data"
            });

            var tag = await _tagServ.GetByIdAsync(id);
            if (tag == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Tag doesn't exist"
            });

            var result = await _tagServ.DeleteAsync(id);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Tag deleted successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Failed to delete tag"
            });
        }
    }
}
