using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_blog_urltitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_category_category_id",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_writer_writer_id",
                table: "blog");

            migrationBuilder.AlterColumn<int>(
                name: "writer_id",
                table: "blog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "blog",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "url_title",
                table: "blog",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_blog_url_title",
                table: "blog",
                column: "url_title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_category_category_id",
                table: "blog",
                column: "category_id",
                principalTable: "category",
                principalColumn: "objectid");

            migrationBuilder.AddForeignKey(
                name: "FK_blog_writer_writer_id",
                table: "blog",
                column: "writer_id",
                principalTable: "writer",
                principalColumn: "objectid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blog_category_category_id",
                table: "blog");

            migrationBuilder.DropForeignKey(
                name: "FK_blog_writer_writer_id",
                table: "blog");

            migrationBuilder.DropIndex(
                name: "IX_blog_url_title",
                table: "blog");

            migrationBuilder.DropColumn(
                name: "url_title",
                table: "blog");

            migrationBuilder.AlterColumn<int>(
                name: "writer_id",
                table: "blog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "category_id",
                table: "blog",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_category_category_id",
                table: "blog",
                column: "category_id",
                principalTable: "category",
                principalColumn: "objectid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blog_writer_writer_id",
                table: "blog",
                column: "writer_id",
                principalTable: "writer",
                principalColumn: "objectid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
