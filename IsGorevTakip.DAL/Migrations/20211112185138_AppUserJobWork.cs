using Microsoft.EntityFrameworkCore.Migrations;

namespace IsGorevTakip.DAL.Migrations
{
    public partial class AppUserJobWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "JobWork",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobWork_AppUserId",
                table: "JobWork",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobWork_AspNetUsers_AppUserId",
                table: "JobWork",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobWork_AspNetUsers_AppUserId",
                table: "JobWork");

            migrationBuilder.DropIndex(
                name: "IX_JobWork_AppUserId",
                table: "JobWork");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "JobWork");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
