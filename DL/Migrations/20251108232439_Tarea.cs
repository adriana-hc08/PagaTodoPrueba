using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    /// <inheritdoc />
    public partial class Tarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tarea");

            migrationBuilder.AddColumn<int>(
                name: "IdStatus",
                table: "Tarea",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IdStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Status__IdStatus", x => x.IdStatus);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_IdStatus",
                table: "Tarea",
                column: "IdStatus");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Status",
                table: "Tarea",
                column: "IdStatus",
                principalTable: "Status",
                principalColumn: "IdStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Status",
                table: "Tarea");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_IdStatus",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "IdStatus",
                table: "Tarea");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tarea",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
