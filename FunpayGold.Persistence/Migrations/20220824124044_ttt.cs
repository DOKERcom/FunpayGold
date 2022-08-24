using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class ttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Proxy",
                table: "Bots",
                newName: "ProxyIp");

            migrationBuilder.RenameColumn(
                name: "AccountPhoneNumber",
                table: "Bots",
                newName: "AccountMobile");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceEntityId",
                table: "Bots",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Bots_ServiceEntityId",
                table: "Bots",
                column: "ServiceEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Services_ServiceEntityId",
                table: "Bots",
                column: "ServiceEntityId",
                principalTable: "Services",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Services_ServiceEntityId",
                table: "Bots");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Bots_ServiceEntityId",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "ServiceEntityId",
                table: "Bots");

            migrationBuilder.RenameColumn(
                name: "ProxyIp",
                table: "Bots",
                newName: "Proxy");

            migrationBuilder.RenameColumn(
                name: "AccountMobile",
                table: "Bots",
                newName: "AccountPhoneNumber");
        }
    }
}
