using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPdotNetDesign.Migrations
{
    /// <inheritdoc />
    public partial class Imagess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfoes",
                table: "StudentInfoes");

            migrationBuilder.RenameTable(
                name: "StudentInfoes",
                newName: "StudentInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentInfo",
                table: "StudentInfo");

            migrationBuilder.RenameTable(
                name: "StudentInfo",
                newName: "StudentInfoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentInfoes",
                table: "StudentInfoes",
                column: "Id");
        }
    }
}
