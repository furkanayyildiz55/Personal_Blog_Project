﻿// <auto-generated />
using System;
using DataAccesLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccesLayer.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int>("CommnetCount")
                        .HasColumnType("int")
                        .HasColumnName("comment_count");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<string>("MainImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("main_image");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("ThumbnailImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("thumbnail_image");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("title");

                    b.Property<string>("UrlTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("url_title");

                    b.Property<int>("ViewsCount")
                        .HasColumnType("int")
                        .HasColumnName("views_count");

                    b.Property<int?>("WriterId")
                        .HasColumnType("int")
                        .HasColumnName("writer_id");

                    b.HasKey("ObjectId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UrlTitle")
                        .IsUnique();

                    b.HasIndex("WriterId");

                    b.ToTable("blog");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BlogTag", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("blog_id");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<int>("TagId")
                        .HasColumnType("int")
                        .HasColumnName("tag_id");

                    b.HasKey("ObjectId");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagId");

                    b.ToTable("blog_tag");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.HasKey("ObjectId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int")
                        .HasColumnName("blog_id");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("ReplyId")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("reply_id");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_ip");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.Property<string>("Useremail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_email");

                    b.HasKey("ObjectId");

                    b.HasIndex("BlogId");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContactUser", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("message");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_email");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_ip");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("ObjectId");

                    b.ToTable("contact_user");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Report", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<int>("CommentId")
                        .HasColumnType("int")
                        .HasColumnName("comment_id");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.HasKey("ObjectId");

                    b.HasIndex("CommentId");

                    b.ToTable("report");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SocialMedia", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<bool>("BlogView")
                        .HasColumnType("bit")
                        .HasColumnName("blog_view");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("PlatformIcon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("platform_icon");

                    b.Property<string>("PlatformName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("platform_name");

                    b.Property<bool>("ProfileView")
                        .HasColumnType("bit")
                        .HasColumnName("profile_view");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("url");

                    b.Property<int>("WriterId")
                        .HasColumnType("int")
                        .HasColumnName("writer_id");

                    b.HasKey("ObjectId");

                    b.HasIndex("WriterId");

                    b.ToTable("social_media");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Subscribe", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("SubscribeEmail")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("subscribe_email");

                    b.Property<string>("UserIp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_ip");

                    b.HasKey("ObjectId");

                    b.ToTable("subscribe");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Tag", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.HasKey("ObjectId");

                    b.ToTable("tag");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("objectid");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("about");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("ObjectIDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_idate");

                    b.Property<int>("ObjectStatus")
                        .HasColumnType("int")
                        .HasColumnName("object_status");

                    b.Property<DateTime?>("ObjectUDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("object_udate");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("profile_image");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("surname");

                    b.HasKey("ObjectId");

                    b.ToTable("writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Blog")
                        .HasForeignKey("CategoryId");

                    b.HasOne("EntityLayer.Concrete.Writer", "Writer")
                        .WithMany("Blog")
                        .HasForeignKey("WriterId");

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BlogTag", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Blog", "Blogs")
                        .WithMany("BlogTag")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Tag", "Tags")
                        .WithMany("BlogTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blogs");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Blog", "Blogs")
                        .WithMany("Comment")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Report", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Comment", "Comments")
                        .WithMany("Report")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SocialMedia", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Writer", "Writers")
                        .WithMany("SocialMedia")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Writers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Navigation("BlogTag");

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Navigation("Report");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Tag", b =>
                {
                    b.Navigation("BlogTag");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Navigation("Blog");

                    b.Navigation("SocialMedia");
                });
#pragma warning restore 612, 618
        }
    }
}
