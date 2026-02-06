using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroSolutions.Identity.Service.Infra.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    SenhaHash = table.Column<string>(type: "varchar(100)", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtores", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtores");
        }
    }
}
