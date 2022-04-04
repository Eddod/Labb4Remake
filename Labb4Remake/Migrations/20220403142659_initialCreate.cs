using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb4Remake.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblInterests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblInterests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "TblPersons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PersonalNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPersons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "TblWebsites",
                columns: table => new
                {
                    WebsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblWebsites", x => x.WebsiteId);
                });

            migrationBuilder.CreateTable(
                name: "TblPersonInterests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    InterestId = table.Column<int>(nullable: false),
                    WebsiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblPersonInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblPersonInterests_TblInterests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "TblInterests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPersonInterests_TblPersons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "TblPersons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblPersonInterests_TblWebsites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "TblWebsites",
                        principalColumn: "WebsiteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TblInterests",
                columns: new[] { "InterestId", "InterestTitle" },
                values: new object[,]
                {
                    { 1, "Nature" },
                    { 2, "Knowledge" },
                    { 3, "Music" }
                });

            migrationBuilder.InsertData(
                table: "TblPersons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PersonalNumber" },
                values: new object[,]
                {
                    { 1, "Harald", "Nybord", "000912-2131" },
                    { 2, "Laban", "Hansson", "19941209-2331" },
                    { 3, "Karl", "Svahn", "19880808-2333" }
                });

            migrationBuilder.InsertData(
                table: "TblWebsites",
                columns: new[] { "WebsiteId", "Link" },
                values: new object[,]
                {
                    { 1, "https://www.youtube.com/channel/UCAL3JXZSzSm8AlZyD3nQdBA" },
                    { 2, "https://sv.wikipedia.org/wiki/Portal:Huvudsida" },
                    { 3, "https://www.spotify.com/se/" }
                });

            migrationBuilder.InsertData(
                table: "TblPersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TblPersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 2, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "TblPersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 3, 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_TblPersonInterests_InterestId",
                table: "TblPersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPersonInterests_PersonId",
                table: "TblPersonInterests",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_TblPersonInterests_WebsiteId",
                table: "TblPersonInterests",
                column: "WebsiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblPersonInterests");

            migrationBuilder.DropTable(
                name: "TblInterests");

            migrationBuilder.DropTable(
                name: "TblPersons");

            migrationBuilder.DropTable(
                name: "TblWebsites");
        }
    }
}
