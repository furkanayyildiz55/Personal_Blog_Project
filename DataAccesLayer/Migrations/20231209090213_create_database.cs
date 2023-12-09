using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    /// <inheritdoc />
    public partial class create_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.objectid);
                });

            migrationBuilder.CreateTable(
                name: "contact_user",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact_user", x => x.objectid);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.objectid);
                });

            migrationBuilder.CreateTable(
                name: "writer",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    about = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_writer", x => x.objectid);
                });

            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    thumbnail_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    main_image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    views_count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment_count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    writer_id = table.Column<int>(type: "int", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.objectid);
                    table.ForeignKey(
                        name: "FK_blog_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blog_writer_writer_id",
                        column: x => x.writer_id,
                        principalTable: "writer",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "social_media",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    platform_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    platform_icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blog_view = table.Column<bool>(type: "bit", nullable: false),
                    profile_view = table.Column<bool>(type: "bit", nullable: false),
                    writer_id = table.Column<int>(type: "int", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_media", x => x.objectid);
                    table.ForeignKey(
                        name: "FK_social_media_writer_writer_id",
                        column: x => x.writer_id,
                        principalTable: "writer",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "blog_tag",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    tag_id = table.Column<int>(type: "int", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_tag", x => x.objectid);
                    table.ForeignKey(
                        name: "FK_blog_tag_blog_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blog",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blog_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    user_ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reply_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    blog_id = table.Column<int>(type: "int", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.objectid);
                    table.ForeignKey(
                        name: "FK_comment_blog_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blog",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    objectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment_id = table.Column<int>(type: "int", nullable: false),
                    object_status = table.Column<int>(type: "int", nullable: false),
                    object_idate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    object_udate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.objectid);
                    table.ForeignKey(
                        name: "FK_report_comment_comment_id",
                        column: x => x.comment_id,
                        principalTable: "comment",
                        principalColumn: "objectid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_category_id",
                table: "blog",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_writer_id",
                table: "blog",
                column: "writer_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_tag_blog_id",
                table: "blog_tag",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_blog_tag_tag_id",
                table: "blog_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_comment_blog_id",
                table: "comment",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_report_comment_id",
                table: "report",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_social_media_writer_id",
                table: "social_media",
                column: "writer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_tag");

            migrationBuilder.DropTable(
                name: "contact_user");

            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "social_media");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "writer");
        }
    }
}
