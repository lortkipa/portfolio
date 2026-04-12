using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StatusBadge = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FunBadge = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abouts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LinkedinLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    IsSeen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    githubLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    demoLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    AboutId = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Abouts_AboutId",
                        column: x => x.AboutId,
                        principalTable: "Abouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTags_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillTags_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Abouts",
                columns: new[] { "Id", "Bio", "FullName", "FunBadge", "JobTitle", "StatusBadge" },
                values: new object[] { 1, "I design and build thoughtful digital products — from responsive interfaces to robust backend systems. Passionate about clean code, great UX, and technology that actually matters.", "Nikoloz Lortkipanidze", "Building cool things", "Full-Stack Developer", "Open to work" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Email", "GithubLink", "LinkedinLink", "Location", "PhoneNumber" },
                values: new object[] { 1, "nikusha191208@gmail.com", "https://github.com/lortkipa", "https://www.linkedin.com/in/nikoloz-lortkipanidze-2b4263329/", "Tbilisi, Georgia", "+995 575 78 03 23" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Desc", "Icon", "Theme", "Title", "demoLink", "githubLink" },
                values: new object[] { 1, "Responsive developer portfolio built to showcase projects, skills, and professional experience with modern UI animations and clean design.", "🌐", 1, "Personal Portfolio Website", null, "https://github.com/lortkipa/portfolio" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Icon", "Title" },
                values: new object[,]
                {
                    { 1, "💻", "Languages" },
                    { 2, "🎨", "Frontend" },
                    { 3, "⚙️", "Backend" },
                    { 4, "🗄️", "Databases & Cloud" },
                    { 5, "🔧", "Tools & DevOps" },
                    { 6, "🤝", "Soft Skills" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "JavaScript" },
                    { 2, "TypeScript" },
                    { 3, "C#" },
                    { 4, "SQL" },
                    { 5, "C" },
                    { 6, "C++" },
                    { 7, "x86-64 Assembly" },
                    { 8, "Angular" },
                    { 9, "HTML" },
                    { 10, "CSS / SCSS" },
                    { 11, "Figma" },
                    { 12, ".NET" },
                    { 13, "Entity Framework Core" },
                    { 14, "REST APIs" },
                    { 15, "Firebase" },
                    { 16, "Mock API" },
                    { 17, "MySQL" },
                    { 18, "Git" },
                    { 19, "Linux" },
                    { 20, "VS Code" },
                    { 21, "Visual Studio" },
                    { 22, "Neovim" },
                    { 23, "Makefile" },
                    { 24, "Team Leadership" },
                    { 25, "Code Review" },
                    { 26, "Mentoring" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTags",
                columns: new[] { "Id", "ProjectId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 1, 4 },
                    { 4, 1, 8 },
                    { 5, 1, 9 },
                    { 6, 1, 10 },
                    { 7, 1, 12 },
                    { 8, 1, 13 },
                    { 9, 1, 14 },
                    { 10, 1, 17 },
                    { 11, 1, 20 },
                    { 12, 1, 21 }
                });

            migrationBuilder.InsertData(
                table: "SkillTags",
                columns: new[] { "Id", "SkillId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 1, 4 },
                    { 5, 1, 5 },
                    { 6, 1, 6 },
                    { 7, 1, 7 },
                    { 8, 2, 8 },
                    { 9, 2, 9 },
                    { 10, 2, 10 },
                    { 11, 2, 11 },
                    { 12, 3, 12 },
                    { 13, 3, 13 },
                    { 14, 3, 14 },
                    { 15, 4, 15 },
                    { 16, 4, 16 },
                    { 17, 4, 17 },
                    { 18, 5, 18 },
                    { 19, 5, 19 },
                    { 20, 5, 20 },
                    { 21, 5, 21 },
                    { 22, 5, 22 },
                    { 23, 5, 23 },
                    { 24, 6, 24 },
                    { 25, 6, 25 },
                    { 26, 6, 26 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AboutId", "ContactId", "PasswordHash" },
                values: new object[] { 1, 1, 1, "hy5OUM6ZkNiwQTMMR8nd0Rvsa1A66ThqmdqFhOm7EsQ=" });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_demoLink",
                table: "Projects",
                column: "demoLink",
                unique: true,
                filter: "[demoLink] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Desc",
                table: "Projects",
                column: "Desc",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_githubLink",
                table: "Projects",
                column: "githubLink",
                unique: true,
                filter: "[githubLink] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Title",
                table: "Projects",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_ProjectId",
                table: "ProjectTags",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTags_TagId",
                table: "ProjectTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Title",
                table: "Skills",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillTags_SkillId",
                table: "SkillTags",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillTags_TagId",
                table: "SkillTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AboutId",
                table: "Users",
                column: "AboutId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ContactId",
                table: "Users",
                column: "ContactId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "SkillTags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Abouts");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
