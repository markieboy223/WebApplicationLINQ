using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class migrationLinqw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Opleidingen_OpleidingId",
                table: "Gebruikers");

            migrationBuilder.DropForeignKey(
                name: "FK_Gebruikers_Vakken_VakId",
                table: "Gebruikers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Gebruikers");

            migrationBuilder.DropColumn(
                name: "Eigenschap",
                table: "Gebruikers");

            migrationBuilder.RenameTable(
                name: "Gebruikers",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruikers_VakId",
                table: "Student",
                newName: "IX_Student_VakId");

            migrationBuilder.RenameIndex(
                name: "IX_Gebruikers_OpleidingId",
                table: "Student",
                newName: "IX_Student_OpleidingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Docent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eigenschap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Leeftijd = table.Column<int>(type: "int", nullable: false),
                    Woonplaats = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpleidingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Docent_Opleidingen_OpleidingId",
                        column: x => x.OpleidingId,
                        principalTable: "Opleidingen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docent_OpleidingId",
                table: "Docent",
                column: "OpleidingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Vakken_VakId",
                table: "Student",
                column: "VakId",
                principalTable: "Vakken",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Opleidingen_OpleidingId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Vakken_VakId",
                table: "Student");

            migrationBuilder.DropTable(
                name: "Docent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Gebruikers");

            migrationBuilder.RenameIndex(
                name: "IX_Student_VakId",
                table: "Gebruikers",
                newName: "IX_Gebruikers_VakId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_OpleidingId",
                table: "Gebruikers",
                newName: "IX_Gebruikers_OpleidingId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Gebruikers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Eigenschap",
                table: "Gebruikers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gebruikers",
                table: "Gebruikers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Opleidingen_OpleidingId",
                table: "Gebruikers",
                column: "OpleidingId",
                principalTable: "Opleidingen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Gebruikers_Vakken_VakId",
                table: "Gebruikers",
                column: "VakId",
                principalTable: "Vakken",
                principalColumn: "Id");
        }
    }
}
