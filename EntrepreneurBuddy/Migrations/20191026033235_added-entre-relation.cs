using Microsoft.EntityFrameworkCore.Migrations;

namespace EntrepreneurBuddy.Migrations
{
    public partial class addedentrerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Entrepenuers_MentoringRequestId",
                table: "Entrepenuers",
                column: "MentoringRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepenuers_MentoringRequests_MentoringRequestId",
                table: "Entrepenuers",
                column: "MentoringRequestId",
                principalTable: "MentoringRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepenuers_MentoringRequests_MentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropIndex(
                name: "IX_Entrepenuers_MentoringRequestId",
                table: "Entrepenuers");
        }
    }
}
