using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class studentopleiding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
