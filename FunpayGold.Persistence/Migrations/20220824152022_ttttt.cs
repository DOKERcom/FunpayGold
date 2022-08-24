using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class ttttt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId",
                table: "Bots");

            migrationBuilder.RenameColumn(
                name: "WorkerEntityId",
                table: "Bots",
                newName: "WorkerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bots_WorkerEntityId",
                table: "Bots",
                newName: "IX_Bots_WorkerId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bots",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Workers_WorkerId",
                table: "Bots",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Workers_WorkerId",
                table: "Bots");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "Bots",
                newName: "WorkerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Bots_WorkerId",
                table: "Bots",
                newName: "IX_Bots_WorkerEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bots",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId",
                table: "Bots",
                column: "WorkerEntityId",
                principalTable: "Workers",
                principalColumn: "Id");
        }
    }
}
