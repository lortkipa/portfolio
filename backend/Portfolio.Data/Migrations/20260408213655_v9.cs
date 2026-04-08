using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Portfolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icon = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
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
                table: "Projects",
                columns: new[] { "Id", "Desc", "Icon", "Theme", "Title", "demoLink", "githubLink" },
                values: new object[,]
                {
                    { 1, "Responsive developer portfolio built to showcase projects, skills, and professional experience with modern UI animations and clean design.", "🌐", 1, "Personal Portfolio Website", null, "https://github.com/lortkipa/portfolio" },
                    { 2, "Full-stack booking platform for managing restaurant reservations and customer scheduling in real time.", "🛒", 1, "Restaurant Reservation System", null, "https://github.com/lortkipa/Restaurant-Reservation-System" },
                    { 3, "Custom experimental programming language developed from scratch in x64 assembly.", "🧩", 2, "Blang — Programming Language", null, "https://github.com/lortkipa/blang" }
                });

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
                    { 1, "C#" },
                    { 2, "ASP.NET Core" },
                    { 3, "Entity Framework Core" },
                    { 4, "MySQL" },
                    { 5, "JavaScript" },
                    { 6, "TypeScript" },
                    { 7, "HTML5" },
                    { 8, "CSS3" },
                    { 9, "REST APIs" },
                    { 10, "Firebase" },
                    { 11, "Mock API" },
                    { 12, "Git" },
                    { 13, "VS Code" },
                    { 14, "Visual Studio" },
                    { 15, "Neovim" },
                    { 16, "Team Leadership" },
                    { 17, "Code Review" },
                    { 18, "Mentoring" },
                    { 19, "Figma" },
                    { 20, "Angular" },
                    { 21, "Bootstrap" },
                    { 22, "x64 asm" },
                    { 23, "Makefile" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTags",
                columns: new[] { "Id", "ProjectId", "TagId" },
                values: new object[,]
                {
                    { 1, 2, 20 },
                    { 2, 2, 8 },
                    { 3, 2, 7 },
                    { 4, 2, 6 },
                    { 5, 2, 1 },
                    { 6, 2, 2 },
                    { 7, 2, 3 },
                    { 8, 2, 4 },
                    { 9, 2, 20 },
                    { 10, 2, 8 },
                    { 11, 2, 7 },
                    { 12, 2, 6 },
                    { 13, 2, 1 },
                    { 14, 2, 2 },
                    { 15, 2, 3 },
                    { 16, 2, 4 },
                    { 17, 3, 22 },
                    { 18, 3, 23 }
                });

            migrationBuilder.InsertData(
                table: "SkillTags",
                columns: new[] { "Id", "SkillId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 5 },
                    { 3, 1, 6 },
                    { 4, 1, 7 },
                    { 5, 1, 8 },
                    { 6, 2, 20 },
                    { 7, 2, 19 },
                    { 8, 2, 21 },
                    { 9, 3, 2 },
                    { 10, 3, 3 },
                    { 11, 3, 9 },
                    { 12, 4, 4 },
                    { 13, 4, 10 },
                    { 14, 4, 11 },
                    { 15, 5, 12 },
                    { 16, 5, 13 },
                    { 17, 5, 14 },
                    { 18, 5, 15 },
                    { 19, 5, 13 },
                    { 20, 6, 16 },
                    { 21, 6, 17 },
                    { 22, 6, 18 }
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTags");

            migrationBuilder.DropTable(
                name: "SkillTags");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
