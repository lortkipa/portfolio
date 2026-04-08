using AutoMapper;
using Portfolio.Data.Entities;
using Portfolio.Service.DTO.Project;
using Portfolio.Service.DTO.ProjectTag;
using Portfolio.Service.DTO.Skill;
using Portfolio.Service.DTO.SkillTag;
using Portfolio.Service.DTO.Tag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Service.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Skill
            CreateMap<Skill, SkillDTO>().ReverseMap();
            CreateMap<CreateSkillDTO, Skill>();
            CreateMap<UpdateSkillDTO, Skill>();

            // Tag
            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<CreateTagDTO, Tag>();
            CreateMap<UpdateTagDTO, Tag>();

            // SkillTag
            CreateMap<SkillTag, SkillTagDTO>().ReverseMap();
            CreateMap<CreateSkillTagDTO, SkillTag>();
            CreateMap<UpdateSkillTagDTO, SkillTag>();

            // Project
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<CreateProjectDTO, Project>();
            CreateMap<UpdateProjectDTO, Project>();

            // ProjectTag
            CreateMap<ProjectTag, ProjectTagDTO>().ReverseMap();
            CreateMap<CreateProjectTagDTO, ProjectTag>();
            CreateMap<UpdateProjectTagDTO, ProjectTag>();
        }
    }
}
