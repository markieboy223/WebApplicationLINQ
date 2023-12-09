using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class vakken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vakken_Opleidingen_OpleidingId",
                table: "Vakken");

            migrationBuilder.AlterColumn<int>(
                name: "OpleidingId",
                table: "Vakken",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vakken_Opleidingen_OpleidingId",
                table: "Vakken",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vakken_Opleidingen_OpleidingId",
                table: "Vakken");

            migrationBuilder.AlterColumn<int>(
                name: "OpleidingId",
                table: "Vakken",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Vakken_Opleidingen_OpleidingId",
                table: "Vakken",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id");
        }
    }
}
