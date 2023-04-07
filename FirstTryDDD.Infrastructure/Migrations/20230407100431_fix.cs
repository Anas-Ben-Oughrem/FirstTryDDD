using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTryDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_BookCategory_CategoryId",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.RenameTable(
                name: "BookCategory",
                newName: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reader",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Author",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Author",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reader_Email",
                table: "Reader",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reader_UserName",
                table: "Reader",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_Email",
                table: "Author",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Author_PhoneNumber",
                table: "Author",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Reader_Email",
                table: "Reader");

            migrationBuilder.DropIndex(
                name: "IX_Reader_UserName",
                table: "Reader");

            migrationBuilder.DropIndex(
                name: "IX_Author_Email",
                table: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Author_PhoneNumber",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "BookCategory");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Reader",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_BookCategory_CategoryId",
                table: "Book",
                column: "CategoryId",
                principalTable: "BookCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
