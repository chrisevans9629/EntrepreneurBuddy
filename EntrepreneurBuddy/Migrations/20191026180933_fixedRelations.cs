using Microsoft.EntityFrameworkCore.Migrations;

namespace EntrepreneurBuddy.Migrations
{
    public partial class fixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepenuers_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropForeignKey(
                name: "FK_MentoringRequests_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "MentoringRequests");

            migrationBuilder.DropIndex(
                name: "IX_MentoringRequests_EntrepreneurMentoringRequestId",
                table: "MentoringRequests");

            migrationBuilder.DropIndex(
                name: "IX_Entrepenuers_EntrepreneurMentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropColumn(
                name: "EntrepreneurMentoringRequestId",
                table: "MentoringRequests");

            migrationBuilder.DropColumn(
                name: "EntrepreneurMentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.CreateIndex(
                name: "IX_EntrepreneurMentoringRequests_EntreprenuerId",
                table: "EntrepreneurMentoringRequests",
                column: "EntreprenuerId");

            migrationBuilder.CreateIndex(
                name: "IX_EntrepreneurMentoringRequests_MentoringRequestId",
                table: "EntrepreneurMentoringRequests",
                column: "MentoringRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntrepreneurMentoringRequests_Entrepenuers_EntreprenuerId",
                table: "EntrepreneurMentoringRequests",
                column: "EntreprenuerId",
                principalTable: "Entrepenuers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntrepreneurMentoringRequests_MentoringRequests_MentoringRequestId",
                table: "EntrepreneurMentoringRequests",
                column: "MentoringRequestId",
                principalTable: "MentoringRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntrepreneurMentoringRequests_Entrepenuers_EntreprenuerId",
                table: "EntrepreneurMentoringRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EntrepreneurMentoringRequests_MentoringRequests_MentoringRequestId",
                table: "EntrepreneurMentoringRequests");

            migrationBuilder.DropIndex(
                name: "IX_EntrepreneurMentoringRequests_EntreprenuerId",
                table: "EntrepreneurMentoringRequests");

            migrationBuilder.DropIndex(
                name: "IX_EntrepreneurMentoringRequests_MentoringRequestId",
                table: "EntrepreneurMentoringRequests");

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurMentoringRequestId",
                table: "MentoringRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurMentoringRequestId",
                table: "Entrepenuers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MentoringRequests_EntrepreneurMentoringRequestId",
                table: "MentoringRequests",
                column: "EntrepreneurMentoringRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrepenuers_EntrepreneurMentoringRequestId",
                table: "Entrepenuers",
                column: "EntrepreneurMentoringRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrepenuers_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "Entrepenuers",
                column: "EntrepreneurMentoringRequestId",
                principalTable: "EntrepreneurMentoringRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MentoringRequests_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "MentoringRequests",
                column: "EntrepreneurMentoringRequestId",
                principalTable: "EntrepreneurMentoringRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
