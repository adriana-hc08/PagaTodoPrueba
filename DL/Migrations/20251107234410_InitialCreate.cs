using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    IdTarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarea__IdTarea", x => x.IdTarea);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");
        }
    }
}
