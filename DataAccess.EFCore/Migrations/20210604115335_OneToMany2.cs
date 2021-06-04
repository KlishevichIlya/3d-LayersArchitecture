using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class OneToMany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_Developers_PreviousDevelopersId",
                table: "WorkHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_Projects_PreviousProjectsId",
                table: "WorkHistory");

            migrationBuilder.RenameColumn(
                name: "PreviousProjectsId",
                table: "WorkHistory",
                newName: "PreviousProjectId");

            migrationBuilder.RenameColumn(
                name: "PreviousDevelopersId",
                table: "WorkHistory",
                newName: "PreviousDeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHistory_PreviousProjectsId",
                table: "WorkHistory",
                newName: "IX_WorkHistory_PreviousProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_Developers_PreviousDeveloperId",
                table: "WorkHistory",
                column: "PreviousDeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_Projects_PreviousProjectId",
                table: "WorkHistory",
                column: "PreviousProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_Developers_PreviousDeveloperId",
                table: "WorkHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkHistory_Projects_PreviousProjectId",
                table: "WorkHistory");

            migrationBuilder.RenameColumn(
                name: "PreviousProjectId",
                table: "WorkHistory",
                newName: "PreviousProjectsId");

            migrationBuilder.RenameColumn(
                name: "PreviousDeveloperId",
                table: "WorkHistory",
                newName: "PreviousDevelopersId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkHistory_PreviousProjectId",
                table: "WorkHistory",
                newName: "IX_WorkHistory_PreviousProjectsId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_Developers_PreviousDevelopersId",
                table: "WorkHistory",
                column: "PreviousDevelopersId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkHistory_Projects_PreviousProjectsId",
                table: "WorkHistory",
                column: "PreviousProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
