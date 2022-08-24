using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class tttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Services_ServiceEntityId",
                table: "Bots");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceEntityId",
                table: "Bots",
                newName: "WorkerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bots_ServiceEntityId",
                table: "Bots",
                newName: "IX_Bots_WorkerEntityId");

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId",
                table: "Bots",
                column: "WorkerEntityId",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId",
                table: "Bots");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.RenameColumn(
                name: "WorkerEntityId",
                table: "Bots",
                newName: "ServiceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bots_WorkerEntityId",
                table: "Bots",
                newName: "IX_Bots_ServiceEntityId");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Services_ServiceEntityId",
                table: "Bots",
                column: "ServiceEntityId",
                principalTable: "Services",
                principalColumn: "Id");
        }
    }
}
