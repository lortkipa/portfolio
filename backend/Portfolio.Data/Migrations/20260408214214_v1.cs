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
            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProjectId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 1, 4 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 6,
                column: "TagId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 7,
                column: "TagId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 8,
                column: "TagId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 9,
                column: "TagId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 10,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 3, 22 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 3, 23 });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ASP.NET");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Entity Framework");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProjectId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 8 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 7 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 6 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 6,
                column: "TagId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 7,
                column: "TagId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 8,
                column: "TagId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 9,
                column: "TagId",
                value: 20);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 10,
                column: "TagId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 7 });

            migrationBuilder.UpdateData(
                table: "ProjectTags",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ProjectId", "TagId" },
                values: new object[] { 2, 6 });

            migrationBuilder.InsertData(
                table: "ProjectTags",
                columns: new[] { "Id", "ProjectId", "TagId" },
                values: new object[,]
                {
                    { 13, 2, 1 },
                    { 14, 2, 2 },
                    { 15, 2, 3 },
                    { 16, 2, 4 },
                    { 17, 3, 22 },
                    { 18, 3, 23 }
                });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ASP.NET Core");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Entity Framework Core");
        }
    }
}
