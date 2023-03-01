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
            migrationBuilder.CreateIndex(
                name: "IX_medias_master_id",
                table: "medias",
                column: "master_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_medias_social_links_master_id",
                table: "medias",
                column: "master_id",
                principalTable: "social_links",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medias_stores_master_id",
                table: "medias",
                column: "master_id",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medias_users_master_id",
                table: "medias",
                column: "master_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medias_social_links_master_id",
                table: "medias");

            migrationBuilder.DropForeignKey(
                name: "FK_medias_stores_master_id",
                table: "medias");

            migrationBuilder.DropForeignKey(
                name: "FK_medias_users_master_id",
                table: "medias");

            migrationBuilder.DropIndex(
                name: "IX_medias_master_id",
                table: "medias");
        }
    }
}
