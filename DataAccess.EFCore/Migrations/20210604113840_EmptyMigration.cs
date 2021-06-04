using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class EmptyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    PreviousDeveloperId = table.Column<int>(type: "int", nullable: false),
                    PreviousProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => new { x.PreviousDeveloperId, x.PreviousProjectId });
                    table.ForeignKey(
                        name: "FK_WorkHistory_Developers_PreviousDeveloperId",
                        column: x => x.PreviousDeveloperId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkHistory_Projects_PreviousProjectId",
                        column: x => x.PreviousProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_PreviousProjectId",
                table: "WorkHistory",
                column: "PreviousProjectId");
        }
    }
}
