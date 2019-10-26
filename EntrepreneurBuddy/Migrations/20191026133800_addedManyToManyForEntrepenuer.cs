using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntrepreneurBuddy.Migrations
{
    public partial class addedManyToManyForEntrepenuer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepenuers_MentoringRequests_MentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropIndex(
                name: "IX_Entrepenuers_MentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropColumn(
                name: "MentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurMentoringRequestId",
                table: "MentoringRequests",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntrepreneurMentoringRequestId",
                table: "Entrepenuers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntrepreneurMentoringRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntrepreneurMentoringRequests", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrepenuers_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "Entrepenuers");

            migrationBuilder.DropForeignKey(
                name: "FK_MentoringRequests_EntrepreneurMentoringRequests_EntrepreneurMentoringRequestId",
                table: "MentoringRequests");

            migrationBuilder.DropTable(
                name: "EntrepreneurMentoringRequests");

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

            migrationBuilder.AddColumn<int>(
                name: "MentoringRequestId",
                table: "Entrepenuers",
                nullable: false,
                defaultValue: 0);

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
    }
}
