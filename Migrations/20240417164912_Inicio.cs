using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicolasCasamen_MVCTaller.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Promo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromoID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promo_Burger_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promo_BurgerId",
                table: "Promo",
                column: "BurgerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promo");
        }
    }
}
