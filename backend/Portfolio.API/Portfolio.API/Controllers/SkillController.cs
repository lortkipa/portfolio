using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.Skill;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ISkillTagService _skillTagServ;
        private readonly ISkillService _skillServ;
        private readonly ITagService _tagServ;

        public SkillController(ISkillTagService skillTagServ, ISkillService skillServ, ITagService tagServ)
        {
            _skillTagServ = skillTagServ;
            _skillServ = skillServ;
            _tagServ = tagServ;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var skills = await _skillServ.GetAllAsync();
            var skillTags = await _skillTagServ.GetAllAsync();
            var tags = await _tagServ.GetAllAsync();

            // Join skills with their tags
            var result = skills.Select(skill => new SkillWithTagsDTO
            {
                Id = skill.Id,
                Icon = skill.Icon,
                Title = skill.Title,
                Tags = skillTags
                    .Where(st => st.SkillId == skill.Id)
                    .Join(tags,
                          st => st.TagId,
                          t => t.Id,
                          (st, t) => new TagDTO { Id = t.Id, Name = t.Name })
                    .ToList()
            }).ToList();

            return Ok(result);
        }
        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult<SkillDTO>> Add([FromBody] CreateSkillDTO model)
        {
            var tag = await _skillServ.CreateAsync(model);
            if (tag == null)
            {
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Failed to add skill"
                });
            }

            return Ok(tag);
        }
        [Authorize]
        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<AuthResponseDTO>> Update(int id, [FromBody] UpdateSkillDTO model)
        {
            var skill = await _skillServ.GetByIdAsync(id);
            if (skill == null)
            {
                return NotFound(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Skill doesn't exist"
                });
            }

            var res = await _skillServ.UpdateAsync(id, model);
            if (!res)
            {
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Failed to update skill"
                });
            }

            return Ok(new AuthResponseDTO 
            {
                Status = true,
                Message = "Skill updated"
            });
        }
        [Authorize]
        [HttpPut("AddTag/{skillId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> AddTag(int skillId, [FromBody] int tagId)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Invalid request data"
            });

            var skill = await _skillServ.GetByIdAsync(skillId);
            if (skill == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Skill doesn't exist"
            });

            var tag = await _tagServ.GetByIdAsync(tagId);
            if (tag == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Tag doesn't exist"
            });

            var result = await _skillTagServ.AddTag(skillId, tagId);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Tag added successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = true,
                Message = "Failed to add tag"
            });
        }
        [Authorize]
        [HttpPut("RemoveTag/{skillId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> RemoveTag(int skillId, [FromBody] int tagId)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Invalid request data"
            });

            var project = await _skillServ.GetByIdAsync(skillId);
            if (project == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Skill doesn't exist"
            });

            var tag = await _tagServ.GetByIdAsync(tagId);
            if (tag == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Tag doesn't exist"
            });

            var result = await _skillTagServ.RemoveTag(skillId, tagId);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Tag removed successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = true,
                Message = "Failed To remove Tag"
            });
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

            var tag = await _skillServ.GetByIdAsync(id);
            if (tag == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Skill doesn't exist"
            });

            var result = await _skillServ.DeleteAsync(id);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Skill removed successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Failed to remove skill"
            });
        }
    }
}
