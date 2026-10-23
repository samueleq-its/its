using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GAM.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixOperaColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nominativo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denominazione = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opera",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inventario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAutore = table.Column<int>(type: "int", nullable: true),
                    Ambito_culturale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datazione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Titolo_soggetto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Immagine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lsreferenceby = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opera", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opera_Autore_IdAutore",
                        column: x => x.IdAutore,
                        principalTable: "Autore",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialeOpera",
                columns: table => new
                {
                    IdMaterialiId = table.Column<int>(type: "int", nullable: false),
                    IdOpereId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialeOpera", x => new { x.IdMaterialiId, x.IdOpereId });
                    table.ForeignKey(
                        name: "FK_MaterialeOpera_Materiale_IdMaterialiId",
                        column: x => x.IdMaterialiId,
                        principalTable: "Materiale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialeOpera_Opera_IdOpereId",
                        column: x => x.IdOpereId,
                        principalTable: "Opera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialeOpera_IdOpereId",
                table: "MaterialeOpera",
                column: "IdOpereId");

            migrationBuilder.CreateIndex(
                name: "IX_Opera_IdAutore",
                table: "Opera",
                column: "IdAutore");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialeOpera");

            migrationBuilder.DropTable(
                name: "Materiale");

            migrationBuilder.DropTable(
                name: "Opera");

            migrationBuilder.DropTable(
                name: "Autore");
        }
    }
}
