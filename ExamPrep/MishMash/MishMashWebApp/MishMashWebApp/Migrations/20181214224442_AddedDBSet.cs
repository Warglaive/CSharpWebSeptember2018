using Microsoft.EntityFrameworkCore.Migrations;

namespace MishMashWebApp.Migrations
{
    public partial class AddedDBSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannel_Channels_ChannelId",
                table: "UserChannel");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannel_Users_UserId",
                table: "UserChannel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChannel",
                table: "UserChannel");

            migrationBuilder.RenameTable(
                name: "UserChannel",
                newName: "UserChannels");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannel_UserId",
                table: "UserChannels",
                newName: "IX_UserChannels_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChannels",
                table: "UserChannels",
                columns: new[] { "ChannelId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannels_Users_UserId",
                table: "UserChannels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Channels_ChannelId",
                table: "UserChannels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserChannels_Users_UserId",
                table: "UserChannels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChannels",
                table: "UserChannels");

            migrationBuilder.RenameTable(
                name: "UserChannels",
                newName: "UserChannel");

            migrationBuilder.RenameIndex(
                name: "IX_UserChannels_UserId",
                table: "UserChannel",
                newName: "IX_UserChannel_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChannel",
                table: "UserChannel",
                columns: new[] { "ChannelId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannel_Channels_ChannelId",
                table: "UserChannel",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserChannel_Users_UserId",
                table: "UserChannel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
