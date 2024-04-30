using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OurTeam",
                table: "OurTeam");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "43bd33ce-2282-42ff-addf-b232e867eb20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26c2aca-ec2e-48c5-80f8-c3e8307fbb87");

            migrationBuilder.RenameTable(
                name: "OurTeam",
                newName: "OurTeams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurTeams",
                table: "OurTeams",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SocialMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    İnstagram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedias", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11476a4e-a96a-45e8-a7d6-7152a106f2eb", null, "Admin", "ADMIN" },
                    { "8a9c7000-496b-42c5-8915-c3a5f8c9a41f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMedias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OurTeams",
                table: "OurTeams");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11476a4e-a96a-45e8-a7d6-7152a106f2eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a9c7000-496b-42c5-8915-c3a5f8c9a41f");

            migrationBuilder.RenameTable(
                name: "OurTeams",
                newName: "OurTeam");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OurTeam",
                table: "OurTeam",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "43bd33ce-2282-42ff-addf-b232e867eb20", null, "Admin", "ADMIN" },
                    { "c26c2aca-ec2e-48c5-80f8-c3e8307fbb87", null, "User", "USER" }
                });
        }
    }
}
