using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonolithAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedlinkedusertoCalenderEventModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "CalenderEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderEvents_Username",
                table: "CalenderEvents",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_CalenderEvents_users_Username",
                table: "CalenderEvents",
                column: "Username",
                principalTable: "users",
                principalColumn: "Username",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalenderEvents_users_Username",
                table: "CalenderEvents");

            migrationBuilder.DropIndex(
                name: "IX_CalenderEvents_Username",
                table: "CalenderEvents");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "CalenderEvents");
        }
    }
}
