using Portfolio.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.DTO.Project
{
    public class UpdateProjectDTO
    {
        public string Icon { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public ProjectThemes Theme { get; set; } = ProjectThemes.Orange;
        public string? githubLink { get; set; }
        public string? demoLink { get; set; }
    }
}
