using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeFollow.DAL.SQLServer.Migrations
{
    public partial class userasAnimeUserStatusProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AnimeUserStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "AnimeUserStatuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AnimeUserStatuses_Users_UserId",
                table: "AnimeUserStatuses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
