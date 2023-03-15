using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPdotNetDesign.Migrations
{
    /// <inheritdoc />
    public partial class userUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRemember",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRemember",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
