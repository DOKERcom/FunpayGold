using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class nefdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    BotId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotActivities_Bots_BotId",
                        column: x => x.BotId,
                        principalTable: "Bots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotActivities_BotId",
                table: "BotActivities",
                column: "BotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotActivities");
        }
    }
}
