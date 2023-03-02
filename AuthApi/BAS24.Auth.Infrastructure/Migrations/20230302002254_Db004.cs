using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db004 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "stores",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "stores");
        }
    }
}
