﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241226134829_mig_update_chart_table")]
    partial class mig_update_chart_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.About", b =>
                {
                    b.Property<int>("AboutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AboutId"));

                    b.Property<string>("AboutDImage1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDImage2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDetails1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutDetails2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AboutMapLocation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("AboutStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("AboutId");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserAbout")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BlogId"));

                    b.Property<string>("BlogContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("BlogCreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("BlogImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("BlogStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BlogThumbnailImage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BlogTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("WriterId")
                        .HasColumnType("int");

                    b.HasKey("BlogId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("WriterId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BlogRaytings", b =>
                {
                    b.Property<int>("BlogRaytingsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("BlogRaytingsId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("BlogRaytingsCount")
                        .HasColumnType("int");

                    b.Property<int>("BlogTotalScore")
                        .HasColumnType("int");

                    b.HasKey("BlogRaytingsId");

                    b.ToTable("BlogRaytings");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CategoryStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Chart", b =>
                {
                    b.Property<int>("ChartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ChartId"));

                    b.Property<int>("ChartCount")
                        .HasColumnType("int");

                    b.Property<string>("ChartName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ChartStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ChartId");

                    b.ToTable("charts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CommentId"));

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.Property<int>("BlogScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("CommenDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("CommentStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CommentTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CommentUserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CommentId");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ContactId"));

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ContactMail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactMessage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ContactStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ContactSubject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ContactUserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ContactId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Receiver")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message2", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MessageId"));

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MessageDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Reading")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ReceiverDeleteStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<bool>("SenderDeleteStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("MessageId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Message2s");
                });

            modelBuilder.Entity("EntityLayer.Concrete.NewsLetter", b =>
                {
                    b.Property<int>("MailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("MailId"));

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("MailStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("MailId");

                    b.ToTable("NewsLetters");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<string>("NotificationColor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NotificationDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("NotificationStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NotificationType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NotificationTypeSymbol")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("EntityLayer.Concrete.UserDraft", b =>
                {
                    b.Property<int>("DraftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DraftId"));

                    b.Property<DateTime>("DraftDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DraftMessageDetails")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("DraftStatus")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DraftSubject")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("DraftId");

                    b.ToTable("UserDrafts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Property<int>("WriterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("WriterId"));

                    b.Property<string>("WriterAbout")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterImage")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterMail")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterName")
                        .HasColumnType("longtext");

                    b.Property<string>("WriterPassword")
                        .HasColumnType("longtext");

                    b.Property<bool>("WriterStatus")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("WriterId");

                    b.ToTable("Writers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Category", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Writer", "Writer")
                        .WithMany("Blogs")
                        .HasForeignKey("WriterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Comment", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Blog", "Blog")
                        .WithMany("CommentId")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message2", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", "Receiver")
                        .WithMany("UserReceiver")
                        .HasForeignKey("ReceiverId");

                    b.HasOne("EntityLayer.Concrete.AppUser", "Sender")
                        .WithMany("UserSender")
                        .HasForeignKey("SenderId");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityLayer.Concrete.AppUser", b =>
                {
                    b.Navigation("UserReceiver");

                    b.Navigation("UserSender");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Blog", b =>
                {
                    b.Navigation("CommentId");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Category", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Writer", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
