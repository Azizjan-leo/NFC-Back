using Microsoft.EntityFrameworkCore.Migrations;

namespace NFC.API.Migrations
{
    public partial class ServiceQuizeResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceQuizeResultId",
                table: "ServiceQuizeAnswer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceQuizeResult",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceQuizeResult", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuizeAnswer_ServiceQuizeResultId",
                table: "ServiceQuizeAnswer",
                column: "ServiceQuizeResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceQuizeAnswer_ServiceQuizeResult_ServiceQuizeResultId",
                table: "ServiceQuizeAnswer",
                column: "ServiceQuizeResultId",
                principalTable: "ServiceQuizeResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceQuizeAnswer_ServiceQuizeResult_ServiceQuizeResultId",
                table: "ServiceQuizeAnswer");

            migrationBuilder.DropTable(
                name: "ServiceQuizeResult");

            migrationBuilder.DropIndex(
                name: "IX_ServiceQuizeAnswer_ServiceQuizeResultId",
                table: "ServiceQuizeAnswer");

            migrationBuilder.DropColumn(
                name: "ServiceQuizeResultId",
                table: "ServiceQuizeAnswer");
        }
    }
}
