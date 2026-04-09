using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Configurations;
using Portfolio.Data.Entities;
using Portfolio.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Data
{
    public class PortfolioContext : DbContext
    {
        // DBSet properties
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillTag> SkillTags { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }

        public PortfolioContext()
        {
        }
        public PortfolioContext(DbContextOptions<PortfolioContext> context) : base(context)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // add configurations
            modelBuilder.ApplyConfiguration(new TagConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());

            // seeding
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, Name = "C#" },
                new Tag { Id = 2, Name = "ASP.NET" },
                new Tag { Id = 3, Name = "Entity Framework" },
                new Tag { Id = 4, Name = "MySQL" },
                new Tag { Id = 5, Name = "JavaScript" },
                new Tag { Id = 6, Name = "TypeScript" },
                new Tag { Id = 7, Name = "HTML5" },
                new Tag { Id = 8, Name = "CSS3" },
                new Tag { Id = 9, Name = "REST APIs" },
                new Tag { Id = 10, Name = "Firebase" },
                new Tag { Id = 11, Name = "Mock API" },
                new Tag { Id = 12, Name = "Git" },
                new Tag { Id = 13, Name = "VS Code" },
                new Tag { Id = 14, Name = "Visual Studio" },
                new Tag { Id = 15, Name = "Neovim" },
                new Tag { Id = 16, Name = "Team Leadership" },
                new Tag { Id = 17, Name = "Code Review" },
                new Tag { Id = 18, Name = "Mentoring" },
                new Tag { Id = 19, Name = "Figma" },
                new Tag { Id = 20, Name = "Angular" },
                new Tag { Id = 21, Name = "Bootstrap" },
                new Tag { Id = 22, Name = "x64 asm" },
                new Tag { Id = 23, Name = "Makefile" }
            );
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Icon = "💻", Title = "Languages" },
                new Skill { Id = 2, Icon = "🎨", Title = "Frontend" },
                new Skill { Id = 3, Icon = "⚙️", Title = "Backend" },
                new Skill { Id = 4, Icon = "🗄️", Title = "Databases & Cloud" },
                new Skill { Id = 5, Icon = "🔧", Title = "Tools & DevOps" },
                new Skill { Id = 6, Icon = "🤝", Title = "Soft Skills" }
            );
            modelBuilder.Entity<SkillTag>().HasData(
                new SkillTag { Id = 1, SkillId = 1, TagId = 1 },
                new SkillTag { Id = 2, SkillId = 1, TagId = 5 },
                new SkillTag { Id = 3, SkillId = 1, TagId = 6 },
                new SkillTag { Id = 4, SkillId = 1, TagId = 7 },
                new SkillTag { Id = 5, SkillId = 1, TagId = 8 },
                new SkillTag { Id = 6, SkillId = 1, TagId = 22 },
                new SkillTag { Id = 7, SkillId = 2, TagId = 20 },
                new SkillTag { Id = 8, SkillId = 2, TagId = 19 },
                new SkillTag { Id = 9, SkillId = 2, TagId = 21 },
                new SkillTag { Id = 10, SkillId = 3, TagId = 2 },
                new SkillTag { Id = 11, SkillId = 3, TagId = 3 },
                new SkillTag { Id = 12, SkillId = 3, TagId = 9 },
                new SkillTag { Id = 13, SkillId = 4, TagId = 4 },
                new SkillTag { Id = 14, SkillId = 4, TagId = 10 },
                new SkillTag { Id = 15, SkillId = 4, TagId = 11 },
                new SkillTag { Id = 16, SkillId = 5, TagId = 12 },
                new SkillTag { Id = 17, SkillId = 5, TagId = 13 },
                new SkillTag { Id = 18, SkillId = 5, TagId = 14 },
                new SkillTag { Id = 19, SkillId = 5, TagId = 15 },
                new SkillTag { Id = 20, SkillId = 5, TagId = 13 },
                new SkillTag { Id = 21, SkillId = 6, TagId = 16 },
                new SkillTag { Id = 22, SkillId = 6, TagId = 17 },
                new SkillTag { Id = 23, SkillId = 6, TagId = 18 }
            );
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Icon = "🌐",
                    Title = "Personal Portfolio Website",
                    Desc = "Responsive developer portfolio built to showcase projects, skills, and professional experience with modern UI animations and clean design.",
                    Theme = ProjectThemes.Orange,
                    githubLink = "https://github.com/lortkipa/portfolio",
                    demoLink = null
                },
                new Project
                {
                    Id = 2,
                    Icon = "🛒",
                    Title = "Restaurant Reservation System",
                    Desc = "Full-stack booking platform for managing restaurant reservations and customer scheduling in real time.",
                    Theme = ProjectThemes.Orange,
                    githubLink = "https://github.com/lortkipa/Restaurant-Reservation-System",
                    demoLink = null
                },
                new Project
                {
                    Id = 3,
                    Icon = "🧩",
                    Title = "Blang — Programming Language",
                    Desc = "Custom experimental programming language developed from scratch in x64 assembly.",
                    Theme = ProjectThemes.Blue,
                    githubLink = "https://github.com/lortkipa/blang",
                    demoLink = null
                }
            );
            modelBuilder.Entity<ProjectTag>().HasData(
                new ProjectTag { Id = 1, ProjectId = 1, TagId = 20 },
                new ProjectTag { Id = 2, ProjectId = 1, TagId = 1 },
                new ProjectTag { Id = 3, ProjectId = 1, TagId = 2 },
                new ProjectTag { Id = 4, ProjectId = 1, TagId = 3 },
                new ProjectTag { Id = 5, ProjectId = 1, TagId = 4 },
                new ProjectTag { Id = 6, ProjectId = 2, TagId = 20 },
                new ProjectTag { Id = 7, ProjectId = 2, TagId = 1 },
                new ProjectTag { Id = 8, ProjectId = 2, TagId = 2 },
                new ProjectTag { Id = 9, ProjectId = 2, TagId = 3 },
                new ProjectTag { Id = 10, ProjectId = 2, TagId = 4 },
                new ProjectTag { Id = 11, ProjectId = 3, TagId = 22 },
                new ProjectTag { Id = 12, ProjectId = 3, TagId = 23 }
            );
            modelBuilder.Entity<Contact>().HasData(
                new Contact 
                {
                    Id = 1,
                    Email = "nikusha191208@gmail.com",
                    Location = "Tbilisi, Georgia",
                    PhoneNumber = "+995 575 78 03 23",
                    GithubLink = "https://github.com/lortkipa",
                    LinkedinLink = "https://www.linkedin.com/in/nikoloz-lortkipanidze-2b4263329/"
                }
            );
            modelBuilder.Entity<User>().HasData(
                new User 
                {
                    Id = 1,
                    ContactId = 1,
                    FullName = "Nikoloz Lortkipanidze"
                }
            );
        }
    }
}
