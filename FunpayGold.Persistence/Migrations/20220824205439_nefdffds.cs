using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class nefdffds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotActivities_Bots_BotId",
                table: "BotActivities");

            migrationBuilder.RenameColumn(
                name: "BotId",
                table: "BotActivities",
                newName: "BotEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BotActivities_BotId",
                table: "BotActivities",
                newName: "IX_BotActivities_BotEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BotActivities_Bots_BotEntityId",
                table: "BotActivities",
                column: "BotEntityId",
                principalTable: "Bots",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotActivities_Bots_BotEntityId",
                table: "BotActivities");

            migrationBuilder.RenameColumn(
                name: "BotEntityId",
                table: "BotActivities",
                newName: "BotId");

            migrationBuilder.RenameIndex(
                name: "IX_BotActivities_BotEntityId",
                table: "BotActivities",
                newName: "IX_BotActivities_BotId");

            migrationBuilder.AddForeignKey(
                name: "FK_BotActivities_Bots_BotId",
                table: "BotActivities",
                column: "BotId",
                principalTable: "Bots",
                principalColumn: "Id");
        }
    }
}
