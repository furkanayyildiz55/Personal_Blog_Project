using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_mail_log : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mail_log",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    send_status = table.Column<bool>(type: "bit", nullable: true),
                    error_cycle = table.Column<int>(type: "int", nullable: true),
                    log_message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail_receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail_subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mail_body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mail_log", x => x.objectid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mail_log");
        }
    }
}
