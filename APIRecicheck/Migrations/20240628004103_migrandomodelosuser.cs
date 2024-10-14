using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIRecicheck.Migrations
{
    /// <inheritdoc />
    public partial class migrandomodelosuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COLETA",
                columns: table => new
                {
                    coletaId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    tipoResiduo = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    dataColeta = table.Column<DateTime>(type: "date", nullable: false),
                    quantidade = table.Column<string>(type: "NVARCHAR2(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COLETA", x => x.coletaId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Role = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COLETA");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
