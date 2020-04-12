using Microsoft.EntityFrameworkCore.Migrations;

namespace UrbanDictionary.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags");

            migrationBuilder.DropIndex(
                name: "IX_WordTags_WordId",
                table: "WordTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords");

            migrationBuilder.DropIndex(
                name: "IX_UserSavedWords_UserId",
                table: "UserSavedWords");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WordTags");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSavedWords");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSavedWords",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags",
                columns: new[] { "WordId", "TagId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords",
                columns: new[] { "UserId", "SavedWordId" });

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 59L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 66L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 67L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 68L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 69L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 70L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 71L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 72L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 73L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 75L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 76L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 77L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 78L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 79L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 80L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 81L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 82L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 83L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 84L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 85L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 86L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 87L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 88L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 89L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 90L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 91L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 92L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 93L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 94L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 95L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 96L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 97L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 98L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 99L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "WordTags",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserSavedWords",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "UserSavedWords",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 59L,
                column: "Name",
                value: "DefaultWordName7");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 66L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 67L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 68L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 69L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 70L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 71L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 72L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 73L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 75L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 76L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 77L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 78L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 79L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 80L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 81L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 82L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 83L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 84L,
                column: "Name",
                value: "DefaultWordName5");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 85L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 86L,
                column: "Name",
                value: "DefaultWordName1");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 87L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 88L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 89L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 90L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 91L,
                column: "Name",
                value: "DefaultWordName0");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 92L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 93L,
                column: "Name",
                value: "DefaultWordName2");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 94L,
                column: "Name",
                value: "DefaultWordName8");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 95L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 96L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 97L,
                column: "Name",
                value: "DefaultWordName6");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 98L,
                column: "Name",
                value: "DefaultWordName4");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 99L,
                column: "Name",
                value: "DefaultWordName3");

            migrationBuilder.UpdateData(
                table: "Words",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Name",
                value: "DefaultWordName9");

            migrationBuilder.CreateIndex(
                name: "IX_WordTags_WordId",
                table: "WordTags",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSavedWords_UserId",
                table: "UserSavedWords",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
