using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Restaurante.Infrastructure.Migrations
{
    public partial class initBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "restaurante",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_restaurante", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "prato",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    restaurante_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prato", x => x.id);
                    table.ForeignKey(
                        name: "FK_prato_restaurante_restaurante_id",
                        column: x => x.restaurante_id,
                        principalTable: "restaurante",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_prato_restaurante_id",
                table: "prato",
                column: "restaurante_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "prato");

            migrationBuilder.DropTable(
                name: "restaurante");
        }
    }
}
