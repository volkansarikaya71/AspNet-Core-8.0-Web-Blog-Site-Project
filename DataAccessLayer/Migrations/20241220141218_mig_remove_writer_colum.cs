using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_remove_writer_colum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_ReceiverId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_ReceiverId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_SenderId",
                table: "Message2s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "FK_Message2s_Writers_ReceiverId",
                table: "Message2s",
                column: "ReceiverId",
                principalTable: "Writers",
                principalColumn: "WriterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_SenderId",
                table: "Message2s",
                column: "SenderId",
                principalTable: "Writers",
                principalColumn: "WriterId");
        }
    }
}
