using Microsoft.EntityFrameworkCore.Migrations;

namespace EntrepreneurBuddy.Migrations
{
    public partial class addedRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MentoringRequests_MentorId",
                table: "MentoringRequests",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MentoringRequests_Mentors_MentorId",
                table: "MentoringRequests",
                column: "MentorId",
                principalTable: "Mentors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MentoringRequests_Mentors_MentorId",
                table: "MentoringRequests");

            migrationBuilder.DropIndex(
                name: "IX_MentoringRequests_MentorId",
                table: "MentoringRequests");
        }
    }
}
