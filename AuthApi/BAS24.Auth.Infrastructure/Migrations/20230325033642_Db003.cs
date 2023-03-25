using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db003 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_store_members_users_UserId",
                table: "store_members");

            migrationBuilder.DropIndex(
                name: "IX_store_members_UserId",
                table: "store_members");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "store_members");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "store_members",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_store_members_UserId",
                table: "store_members",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_store_members_users_UserId",
                table: "store_members",
                column: "UserId",
                principalTable: "users",
                principalColumn: "id");
        }
    }
}
