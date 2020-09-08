using Microsoft.EntityFrameworkCore.Migrations;

namespace NFC.API.Migrations
{
    public partial class serviceQuizeAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceQuizeAnswer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    Answer = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceQuizeAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceQuizeAnswer_ServiceQuizeQuestion_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "ServiceQuizeQuestion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceQuizeAnswer_QuestionId",
                table: "ServiceQuizeAnswer",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceQuizeAnswer");
        }
    }
}
