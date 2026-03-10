using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonolithAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedusertoRefreshToken2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "refreshTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_refreshTokens_Username",
                table: "refreshTokens",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_refreshTokens_users_Username",
                table: "refreshTokens",
                column: "Username",
                principalTable: "users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_refreshTokens_users_Username",
                table: "refreshTokens");

            migrationBuilder.DropIndex(
                name: "IX_refreshTokens_Username",
                table: "refreshTokens");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "refreshTokens");
        }
    }
}
