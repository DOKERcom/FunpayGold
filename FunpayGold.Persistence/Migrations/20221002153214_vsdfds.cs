using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunpayGold.Persistence.Migrations
{
    public partial class vsdfds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotItemEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyItemName = table.Column<string>(type: "text", nullable: false),
                    Items = table.Column<List<string>>(type: "text[]", nullable: false),
                    BotEntityId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotItemEntity_Bots_BotEntityId",
                        column: x => x.BotEntityId,
                        principalTable: "Bots",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotItemEntity_BotEntityId",
                table: "BotItemEntity",
                column: "BotEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotItemEntity");
        }
    }
}
