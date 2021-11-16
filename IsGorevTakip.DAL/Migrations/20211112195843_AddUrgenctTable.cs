using Microsoft.EntityFrameworkCore.Migrations;

namespace IsGorevTakip.DAL.Migrations
{
    public partial class AddUrgenctTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UrgencyId",
                table: "JobWork",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Urgency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urgency", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobWork_UrgencyId",
                table: "JobWork",
                column: "UrgencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobWork_Urgency_UrgencyId",
                table: "JobWork",
                column: "UrgencyId",
                principalTable: "Urgency",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobWork_Urgency_UrgencyId",
                table: "JobWork");

            migrationBuilder.DropTable(
                name: "Urgency");

            migrationBuilder.DropIndex(
                name: "IX_JobWork_UrgencyId",
                table: "JobWork");

            migrationBuilder.DropColumn(
                name: "UrgencyId",
                table: "JobWork");
        }
    }
}
