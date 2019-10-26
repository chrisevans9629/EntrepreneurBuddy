using Microsoft.EntityFrameworkCore.Migrations;

namespace EntrepreneurBuddy.Migrations
{
    public partial class addedentrerequestIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EntreprenuerId",
                table: "EntrepreneurMentoringRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MentoringRequestId",
                table: "EntrepreneurMentoringRequests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntreprenuerId",
                table: "EntrepreneurMentoringRequests");

            migrationBuilder.DropColumn(
                name: "MentoringRequestId",
                table: "EntrepreneurMentoringRequests");
        }
    }
}
