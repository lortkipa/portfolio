
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Dal.Repositories;
using Portfolio.Data;
using Portfolio.Service;
using Portfolio.Service.Interfaces;
using Portfolio.Service.Mapping;

namespace Portfolio.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular", policy =>
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod());
            });

            // DB connection
            builder.Services.AddDbContext<PortfolioContext>(options => {
                options.UseSqlServer(builder.Configuration.GetConnectionString("PortfolioDBConnection"));
            });

            builder.Services.AddScoped<DbContext, PortfolioContext>();

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

            // Add repositories to the container
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ISkillTagRepository, SkillTagRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IProjectTagRepository, ProjectTagRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // Add services to the container
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<ISkillTagService, SkillTagService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectTagService, ProjectTagService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors("AllowAngular");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
