using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_maillog2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "blog_id",
                table: "mail_log",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "subscribe_id",
                table: "mail_log",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "blog_id",
                table: "mail_log");

            migrationBuilder.DropColumn(
                name: "subscribe_id",
                table: "mail_log");
        }
    }
}
