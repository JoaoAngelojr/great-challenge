using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace great_challenge.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 450, nullable: false),
                    Cpf = table.Column<string>(maxLength: 11, nullable: false),
                    Rg = table.Column<string>(maxLength: 13, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    MothersName = table.Column<string>(maxLength: 450, nullable: false),
                    FathersName = table.Column<string>(maxLength: 450, nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Cpf",
                table: "User",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Rg",
                table: "User",
                column: "Rg",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
