using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO;
using Portfolio.Service.DTO.Project;
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
        [Authorize]
        [HttpPost("Add")]
        public async Task<ActionResult<ProjectDTO>> Add([FromBody] CreateProjectDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new AuthResponseDTO
                {
                    Status = false,
                    Message = "Invalid Request Data"
                });

            var result = await _projectServ.CreateAsync(model);

            if (result != null)
                return Ok(result);

            return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Failed to create project"
            });
        }
        [Authorize]
        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<AuthResponseDTO>> Update(int id, [FromBody] UpdateProjectDTO model)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
                                    {
                                        Status = false,
                                        Message = "Invalid Request Data"
                                    });

            var project = await _projectServ.GetByIdAsync(id);
            if (project == null) return NotFound(new AuthResponseDTO
                                {
                                    Status = false,
                                    Message = "Project doesn't exist"
                                });

            var result = await _projectServ.UpdateAsync(id, model);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Project updated successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = true,
                Message = "Failed to update project"
            });
        }
        [Authorize]
        [HttpPut("AddTag/{projectId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> AddTag(int projectId, [FromBody] int tagId)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
                                    {
                                        Status = false,
                                        Message = "Invalid request data"
                                    });

            var project = await _projectServ.GetByIdAsync(projectId);
            if (project == null) return NotFound(new AuthResponseDTO
                                {
                                    Status = false,
                                    Message = "Project doesn't exist"
                                });

            var tag = await _tagServ.GetByIdAsync(tagId);
                            if (tag == null) return NotFound(new AuthResponseDTO
                            {
                                Status = false,
                                Message = "Tag doesn't exist"
                            });

            var result = await _projectTagServ.AddTag(projectId, tagId);
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
        [HttpPut("RemoveTag/{projectId:int}")]
        public async Task<ActionResult<AuthResponseDTO>> RemoveTag(int projectId, [FromBody] int tagId)
        {
            if (!ModelState.IsValid) return BadRequest(new AuthResponseDTO
                                    {
                                        Status = false,
                                        Message = "Invalid request data"
                                    });

            var project = await _projectServ.GetByIdAsync(projectId);
                                if (project == null) return NotFound(new AuthResponseDTO
                                {
                                    Status = false,
                                    Message = "Project doesn't exist"
                                });

            var tag = await _tagServ.GetByIdAsync(tagId);
                            if (tag == null) return NotFound(new AuthResponseDTO
                            {
                                Status = false,
                                Message = "Tag doesn't exist"
                            });

            var result = await _projectTagServ.RemoveTag(projectId, tagId);
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

            var project = await _projectServ.GetByIdAsync(id);
            if (project == null) return NotFound(new AuthResponseDTO
            {
                Status = false,
                Message = "Project doesn't exist"
            });

            var result = await _projectServ.DeleteAsync(id);
            if (result)
            {
                return Ok(new AuthResponseDTO
                {
                    Status = true,
                    Message = "Project deleted successfully"
                });
            }

            return BadRequest(new AuthResponseDTO
            {
                Status = false,
                Message = "Failed to delete project"
            });
        }
    }
}