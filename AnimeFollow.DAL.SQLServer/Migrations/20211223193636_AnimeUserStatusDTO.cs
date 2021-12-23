using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeFollow.DAL.SQLServer.Migrations
{
    public partial class AnimeUserStatusDTO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUserStatuses_Animes_AnimeId",
                table: "AnimeUserStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses");

            migrationBuilder.DropIndex(
                name: "IX_AnimeUserStatuses_AnimeId",
                table: "AnimeUserStatuses");

            migrationBuilder.DropIndex(
                name: "IX_AnimeUserStatuses_UserId",
                table: "AnimeUserStatuses");

            migrationBuilder.RenameColumn(
                name: "DernierEpisodeEcoute",
                table: "AnimeUserStatuses",
                newName: "LastEpisodeWatched");

            migrationBuilder.CreateTable(
                name: "AnimeUserStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimeId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DernierEpisodeEcoute = table.Column<int>(type: "int", nullable: false),
                    URISourceAnime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentNote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeUserStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimeUserStatus_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimeUserStatus_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeUserStatus_AnimeId",
                table: "AnimeUserStatus",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeUserStatus_UserId",
                table: "AnimeUserStatus",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeUserStatus");

            migrationBuilder.RenameColumn(
                name: "LastEpisodeWatched",
                table: "AnimeUserStatuses",
                newName: "DernierEpisodeEcoute");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeUserStatuses_AnimeId",
                table: "AnimeUserStatuses",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeUserStatuses_UserId",
                table: "AnimeUserStatuses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUserStatuses_Animes_AnimeId",
                table: "AnimeUserStatuses",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
