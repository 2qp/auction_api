using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace auction_api.Migrations
{
    /// <inheritdoc />
    public partial class addUserAuctionStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuctions_AspNetUsers_UserId",
                table: "UserAuctions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserAuctions");

            migrationBuilder.AddColumn<long>(
                name: "StatusId",
                table: "UserAuctions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UserAuctions_StatusId",
                table: "UserAuctions",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuctions_AspNetUsers_UserId",
                table: "UserAuctions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuctions_Statuses_StatusId",
                table: "UserAuctions",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAuctions_AspNetUsers_UserId",
                table: "UserAuctions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAuctions_Statuses_StatusId",
                table: "UserAuctions");

            migrationBuilder.DropIndex(
                name: "IX_UserAuctions_StatusId",
                table: "UserAuctions");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "UserAuctions");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "UserAuctions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAuctions_AspNetUsers_UserId",
                table: "UserAuctions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
