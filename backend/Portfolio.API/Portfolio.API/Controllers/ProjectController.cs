using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.DTO.Skill;
using Portfolio.Service.DTO.Tag;
using Portfolio.Service.Interfaces;

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectTagService _projectTagServ;
        private readonly IProjectService _projectServ;
        private readonly ITagService _tagServ;

        public ProjectController(IProjectTagService projectTagServ, IProjectService projectServ, ITagService tagServ)
        {
            _projectTagServ = projectTagServ;
            _projectServ = projectServ;
            _tagServ = tagServ;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var projects = await _projectServ.GetAllAsync();
            var projectTags = await _projectTagServ.GetAllAsync();
            var tags = await _tagServ.GetAllAsync();

            // Map projects with tags
            var result = projects.Select(project => new
            {
                Id = project.Id,
                Icon = project.Icon,
                Title = project.Title,
                Desc = project.Desc,
                Theme = project.Theme,
                githubLink = project.githubLink,
                demoLink = project.demoLink,
                Tags = projectTags
                    .Where(pt => pt.ProjectId == project.Id)
                    .Join(tags,
                          pt => pt.TagId,
                          t => t.Id,
                          (pt, t) => new TagDTO
                          {
                              Id = t.Id,
                              Name = t.Name
                          })
                    .ToList()
            }).ToList();

            return Ok(result);
        }
    }
}