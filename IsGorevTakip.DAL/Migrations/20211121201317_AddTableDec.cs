using Microsoft.EntityFrameworkCore.Migrations;

namespace IsGorevTakip.DAL.Migrations
{
    public partial class AddTableDec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declarations_AspNetUsers_AppUserId",
                table: "Declarations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declarations",
                table: "Declarations");

            migrationBuilder.RenameTable(
                name: "Declarations",
                newName: "Declarationns");

            migrationBuilder.RenameIndex(
                name: "IX_Declarations_AppUserId",
                table: "Declarationns",
                newName: "IX_Declarationns_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declarationns",
                table: "Declarationns",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Declarationns_AspNetUsers_AppUserId",
                table: "Declarationns",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Declarationns_AspNetUsers_AppUserId",
                table: "Declarationns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Declarationns",
                table: "Declarationns");

            migrationBuilder.RenameTable(
                name: "Declarationns",
                newName: "Declarations");

            migrationBuilder.RenameIndex(
                name: "IX_Declarationns_AppUserId",
                table: "Declarations",
                newName: "IX_Declarations_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Declarations",
                table: "Declarations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Declarations_AspNetUsers_AppUserId",
                table: "Declarations",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
