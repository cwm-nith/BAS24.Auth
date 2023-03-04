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
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
                    password = table.Column<string>(type: "text", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: true),
                    phone = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    is_lock = table.Column<bool>(type: "boolean", nullable: true),
                    is_approve = table.Column<bool>(type: "boolean", nullable: false),
                    region_name = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
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
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    code = table.Column<string>(type: "text", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_medias_social_links_master_id",
                        column: x => x.master_id,
                        principalTable: "social_links",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medias_stores_master_id",
                        column: x => x.master_id,
                        principalTable: "stores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medias_users_master_id",
                        column: x => x.master_id,
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
                    permission = table.Column<int>(type: "integer", nullable: false),
                    accepted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                        name: "FK_store_members_users_member_id",
                        column: x => x.member_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_medias_master_id",
                table: "medias",
                column: "master_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_social_user_links_social_link_id",
                table: "social_user_links",
                column: "social_link_id");

            migrationBuilder.CreateIndex(
                name: "IX_social_user_links_store_id",
                table: "social_user_links",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_store_members_member_id",
                table: "store_members",
                column: "member_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_store_members_store_id",
                table: "store_members",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_stores_owner_id",
                table: "stores",
                column: "owner_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "add_member_to_store_requests");

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

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
