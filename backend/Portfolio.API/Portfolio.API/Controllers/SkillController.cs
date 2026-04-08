using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
