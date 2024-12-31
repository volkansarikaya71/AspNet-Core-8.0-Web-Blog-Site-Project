using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_appuser_with_message2s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Message2s_ReceiverId",
                table: "Message2s",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2s",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_ReceiverId",
                table: "Message2s",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderId",
                table: "Message2s",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_ReceiverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_SenderId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_ReceiverId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2s");
        }
    }
}
