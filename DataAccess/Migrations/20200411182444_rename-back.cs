using Microsoft.EntityFrameworkCore.Migrations;

namespace UrbanDictionary.DataAccess.Migrations
{
    public partial class renameback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWord_Word_SavedWordId",
                table: "UserSavedWord");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWord_AspNetUsers_UserId",
                table: "UserSavedWord");

            migrationBuilder.DropForeignKey(
                name: "FK_Word_AspNetUsers_AuthorId",
                table: "Word");

            migrationBuilder.DropForeignKey(
                name: "FK_WordTag_Tag_TagId",
                table: "WordTag");

            migrationBuilder.DropForeignKey(
                name: "FK_WordTag_Word_WordId",
                table: "WordTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordTag",
                table: "WordTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Word",
                table: "Word");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSavedWord",
                table: "UserSavedWord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "WordTag",
                newName: "WordTags");

            migrationBuilder.RenameTable(
                name: "Word",
                newName: "Words");

            migrationBuilder.RenameTable(
                name: "UserSavedWord",
                newName: "UserSavedWords");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_WordTag_WordId",
                table: "WordTags",
                newName: "IX_WordTags_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_WordTag_TagId",
                table: "WordTags",
                newName: "IX_WordTags_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Word_AuthorId",
                table: "Words",
                newName: "IX_Words_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSavedWord_UserId",
                table: "UserSavedWords",
                newName: "IX_UserSavedWords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSavedWord_SavedWordId",
                table: "UserSavedWords",
                newName: "IX_UserSavedWords_SavedWordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Words",
                table: "Words",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWords_Words_SavedWordId",
                table: "UserSavedWords",
                column: "SavedWordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Words_AspNetUsers_AuthorId",
                table: "Words",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordTags_Tags_TagId",
                table: "WordTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordTags_Words_WordId",
                table: "WordTags",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWords_Words_SavedWordId",
                table: "UserSavedWords");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSavedWords_AspNetUsers_UserId",
                table: "UserSavedWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Words_AspNetUsers_AuthorId",
                table: "Words");

            migrationBuilder.DropForeignKey(
                name: "FK_WordTags_Tags_TagId",
                table: "WordTags");

            migrationBuilder.DropForeignKey(
                name: "FK_WordTags_Words_WordId",
                table: "WordTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordTags",
                table: "WordTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Words",
                table: "Words");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSavedWords",
                table: "UserSavedWords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "WordTags",
                newName: "WordTag");

            migrationBuilder.RenameTable(
                name: "Words",
                newName: "Word");

            migrationBuilder.RenameTable(
                name: "UserSavedWords",
                newName: "UserSavedWord");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_WordTags_WordId",
                table: "WordTag",
                newName: "IX_WordTag_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_WordTags_TagId",
                table: "WordTag",
                newName: "IX_WordTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_Words_AuthorId",
                table: "Word",
                newName: "IX_Word_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSavedWords_UserId",
                table: "UserSavedWord",
                newName: "IX_UserSavedWord_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserSavedWords_SavedWordId",
                table: "UserSavedWord",
                newName: "IX_UserSavedWord_SavedWordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordTag",
                table: "WordTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Word",
                table: "Word",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSavedWord",
                table: "UserSavedWord",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWord_Word_SavedWordId",
                table: "UserSavedWord",
                column: "SavedWordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSavedWord_AspNetUsers_UserId",
                table: "UserSavedWord",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Word_AspNetUsers_AuthorId",
                table: "Word",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WordTag_Tag_TagId",
                table: "WordTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WordTag_Word_WordId",
                table: "WordTag",
                column: "WordId",
                principalTable: "Word",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
