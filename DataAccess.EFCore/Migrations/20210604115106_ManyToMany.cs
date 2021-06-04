using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Projects_CurrentProjectId",
                table: "Developers");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentProjectId",
                table: "Developers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    PreviousDevelopersId = table.Column<int>(type: "int", nullable: false),
                    PreviousProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => new { x.PreviousDevelopersId, x.PreviousProjectsId });
                    table.ForeignKey(
                        name: "FK_WorkHistory_Developers_PreviousDevelopersId",
                        column: x => x.PreviousDevelopersId,
                        principalTable: "Developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkHistory_Projects_PreviousProjectsId",
                        column: x => x.PreviousProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_PreviousProjectsId",
                table: "WorkHistory",
                column: "PreviousProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Projects_CurrentProjectId",
                table: "Developers",
                column: "CurrentProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Developers_Projects_CurrentProjectId",
                table: "Developers");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentProjectId",
                table: "Developers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Developers_Projects_CurrentProjectId",
                table: "Developers",
                column: "CurrentProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
