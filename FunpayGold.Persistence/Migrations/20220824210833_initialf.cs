using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class initialf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId1",
                table: "Bots");

            migrationBuilder.DropIndex(
                name: "IX_Bots_WorkerEntityId1",
                table: "Bots");

            migrationBuilder.DropColumn(
                name: "WorkerEntityId1",
                table: "Bots");

            migrationBuilder.AlterColumn<Guid>(
                name: "WorkerEntityId",
                table: "Bots",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bots_WorkerEntityId",
                table: "Bots",
                column: "WorkerEntityId");

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

            migrationBuilder.DropIndex(
                name: "IX_Bots_WorkerEntityId",
                table: "Bots");

            migrationBuilder.AlterColumn<string>(
                name: "WorkerEntityId",
                table: "Bots",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "WorkerEntityId1",
                table: "Bots",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bots_WorkerEntityId1",
                table: "Bots",
                column: "WorkerEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bots_Workers_WorkerEntityId1",
                table: "Bots",
                column: "WorkerEntityId1",
                principalTable: "Workers",
                principalColumn: "Id");
        }
    }
}
