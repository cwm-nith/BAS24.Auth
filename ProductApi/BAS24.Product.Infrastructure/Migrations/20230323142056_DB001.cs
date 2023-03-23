using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BAS24.Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DB001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    symbol = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false),
                    base_currency = table.Column<bool>(type: "boolean", nullable: false),
                    local_currency = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_currencies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner_id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exchange_rate",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    currency_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rate = table.Column<decimal>(type: "numeric", nullable: false),
                    set_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    local_set_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    base_set_rate = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exchange_rate", x => x.id);
                    table.ForeignKey(
                        name: "FK_exchange_rate_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "store_members",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    local_store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    store_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    permission = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_exchange_rate_currency_id",
                table: "exchange_rate",
                column: "currency_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_store_members_store_id",
                table: "store_members",
                column: "store_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exchange_rate");

            migrationBuilder.DropTable(
                name: "store_members");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}
