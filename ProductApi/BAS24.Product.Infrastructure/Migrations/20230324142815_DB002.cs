using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DB002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "store_members");

            migrationBuilder.AddColumn<Guid>(
                name: "member_id",
                table: "store_members",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "member_id",
                table: "store_members");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "store_members",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
