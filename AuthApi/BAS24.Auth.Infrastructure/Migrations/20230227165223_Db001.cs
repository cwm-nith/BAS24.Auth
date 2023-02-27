using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Db001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    master_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "social_links",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_links", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: false),
                    phones = table.Column<string[]>(type: "text[]", nullable: false),
                    emails = table.Column<string[]>(type: "text[]", nullable: false),
                    tags = table.Column<string[]>(type: "text[]", nullable: false),
                    key_words = table.Column<string[]>(type: "text[]", nullable: false),
                    categoryIds = table.Column<Guid[]>(type: "uuid[]", nullable: false),
                    price_rating = table.Column<int>(type: "integer", nullable: false),
                    store_rating = table.Column<int>(type: "integer", nullable: false),
                    start_working_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_working_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.id);
                    table.ForeignKey(
                        name: "FK_stores_users_owner_id",
                        column: x => x.owner_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "social_user_links",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    social_link_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_user_links", x => x.id);
                    table.ForeignKey(
                        name: "FK_social_user_links_social_links_social_link_id",
                        column: x => x.social_link_id,
                        principalTable: "social_links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_social_user_links_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    member_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_member_role = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_store_members", x => x.id);
                    table.ForeignKey(
                        name: "FK_store_members_stores_store_id",
                        column: x => x.store_id,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_store_members_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_social_user_links_social_link_id",
                table: "social_user_links",
                column: "social_link_id");

            migrationBuilder.CreateIndex(
                name: "IX_social_user_links_store_id",
                table: "social_user_links",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_members_store_id",
                table: "store_members",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_members_UserId",
                table: "store_members",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_stores_owner_id",
                table: "stores",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.DropTable(
                name: "social_user_links");

            migrationBuilder.DropTable(
                name: "store_members");

            migrationBuilder.DropTable(
                name: "social_links");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");
        }
    }
}
