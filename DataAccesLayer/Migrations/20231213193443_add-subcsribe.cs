using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class addsubcsribe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "subscribe",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscribe", x => x.objectid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "subscribe");
        }
    }
}
