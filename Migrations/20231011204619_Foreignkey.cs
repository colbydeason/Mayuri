using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mayuri.Migrations
{
    /// <inheritdoc />
    public partial class Foreignkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Logs_SourceId",
                table: "Logs",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Sources_SourceId",
                table: "Logs",
                column: "SourceId",
                principalTable: "Sources",
                principalColumn: "SourceId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Sources_SourceId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_SourceId",
                table: "Logs");
        }
    }
}
