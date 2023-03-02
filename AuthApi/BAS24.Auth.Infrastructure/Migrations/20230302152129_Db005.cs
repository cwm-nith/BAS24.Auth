using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db005 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "store_member_role",
                table: "store_members",
                newName: "permission");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "permission",
                table: "store_members",
                newName: "store_member_role");
        }
    }
}
