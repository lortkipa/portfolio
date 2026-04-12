
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Dal.Repositories;
using Portfolio.Data;
using Portfolio.Service;
using Portfolio.Service.Interfaces;
using Portfolio.Service.Mapping;
using System.Security.Claims;
using System.Text;

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

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(builder.Configuration["JWTConfig:Key"])),

             ValidateIssuer = false,
             ValidateAudience = false,
             ValidateLifetime = true,

             // 🔹 Only name identifier (userId) is relevant
             NameClaimType = ClaimTypes.NameIdentifier,
             RoleClaimType = ClaimTypes.Role // optional, won't be used
         };

         options.Events = new JwtBearerEvents
         {
             OnMessageReceived = context =>
             {
                 // 1️⃣ Check cookie first (optional)
                 if (context.Request.Cookies.ContainsKey("Token"))
                 {
                     context.Token = context.Request.Cookies["Token"];
                 }

                 // 2️⃣ Fallback to Authorization header
                 if (string.IsNullOrEmpty(context.Token) &&
                     context.Request.Headers.ContainsKey("Authorization"))
                 {
                     var authHeader = context.Request.Headers["Authorization"].ToString();
                     if (authHeader.StartsWith("Bearer "))
                     {
                         context.Token = authHeader.Substring("Bearer ".Length).Trim();
                     }
                 }

                 return Task.CompletedTask;
             }
         };
     });

            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            // Add repositories to the container
            builder.Services.AddScoped<ITagRepository, TagRepository>();
            builder.Services.AddScoped<ISkillRepository, SkillRepository>();
            builder.Services.AddScoped<ISkillTagRepository, SkillTagRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<IProjectTagRepository, ProjectTagRepository>();
            builder.Services.AddScoped<IContactRepository, ContactRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAboutRepository, AboutRepository>();
            builder.Services.AddScoped<IMessageRepository, MessageRepository>();

            // Add services to the container
            builder.Services.AddScoped<ITagService, TagService>();
            builder.Services.AddScoped<ISkillService, SkillService>();
            builder.Services.AddScoped<ISkillTagService, SkillTagService>();
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectTagService, ProjectTagService>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAboutService, AboutService>();
            builder.Services.AddScoped<IMessageService, MessageService>();

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
