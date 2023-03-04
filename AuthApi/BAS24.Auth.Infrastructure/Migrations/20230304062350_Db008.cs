using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db008 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "accepted",
                table: "store_members",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "add_member_to_store_requests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_member_id = table.Column<Guid>(type: "uuid", nullable: false),
                    member_id = table.Column<Guid>(type: "uuid", nullable: false),
                    by_id = table.Column<Guid>(type: "uuid", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    by = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_add_member_to_store_requests", x => x.id);
                    table.ForeignKey(
                        name: "FK_add_member_to_store_requests_store_members_store_member_id",
                        column: x => x.store_member_id,
                        principalTable: "store_members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_add_member_to_store_requests_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_add_member_to_store_requests_users_by_id",
                        column: x => x.by_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_add_member_to_store_requests_users_member_id",
                        column: x => x.member_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_add_member_to_store_requests_by_id",
                table: "add_member_to_store_requests",
                column: "by_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_add_member_to_store_requests_member_id",
                table: "add_member_to_store_requests",
                column: "member_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_add_member_to_store_requests_store_id",
                table: "add_member_to_store_requests",
                column: "store_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_add_member_to_store_requests_store_member_id",
                table: "add_member_to_store_requests",
                column: "store_member_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "add_member_to_store_requests");

            migrationBuilder.DropColumn(
                name: "accepted",
                table: "store_members");
        }
    }
}
