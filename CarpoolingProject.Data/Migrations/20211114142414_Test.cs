using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpoolingProject.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelApplication_Travels_TravelId",
                table: "TravelApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelApplication_Users_ApplicantId",
                table: "TravelApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelApplication",
                table: "TravelApplication");

            migrationBuilder.RenameTable(
                name: "TravelApplication",
                newName: "TravelApplications");

            migrationBuilder.RenameIndex(
                name: "IX_TravelApplication_TravelId",
                table: "TravelApplications",
                newName: "IX_TravelApplications_TravelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelApplications",
                table: "TravelApplications",
                columns: new[] { "ApplicantId", "TravelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TravelApplications_Travels_TravelId",
                table: "TravelApplications",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelApplications_Users_ApplicantId",
                table: "TravelApplications",
                column: "ApplicantId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TravelApplications_Travels_TravelId",
                table: "TravelApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelApplications_Users_ApplicantId",
                table: "TravelApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelApplications",
                table: "TravelApplications");

            migrationBuilder.RenameTable(
                name: "TravelApplications",
                newName: "TravelApplication");

            migrationBuilder.RenameIndex(
                name: "IX_TravelApplications_TravelId",
                table: "TravelApplication",
                newName: "IX_TravelApplication_TravelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelApplication",
                table: "TravelApplication",
                columns: new[] { "ApplicantId", "TravelId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TravelApplication_Travels_TravelId",
                table: "TravelApplication",
                column: "TravelId",
                principalTable: "Travels",
                principalColumn: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelApplication_Users_ApplicantId",
                table: "TravelApplication",
                column: "ApplicantId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
