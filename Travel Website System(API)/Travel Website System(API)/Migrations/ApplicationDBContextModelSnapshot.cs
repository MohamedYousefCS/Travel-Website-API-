﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel_Website_System_API.Models;

#nullable disable

namespace Travel_Website_System_API_.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastSeen")
                        .HasColumnType("datetime2");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("allowingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("packageId")
                        .HasColumnType("int");

                    b.Property<int?>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("packageId");

                    b.ToTable("BookingPackages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Data")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("allowingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("serviceId");

                    b.ToTable("BookingServices");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("customerServiceId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("clientId")
                        .IsUnique()
                        .HasFilter("[clientId] IS NOT NULL");

                    b.HasIndex("customerServiceId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ClientConnection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ClientConnections");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.CustomerService", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("CustomerServices");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.LovePackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("packageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("packageId");

                    b.ToTable("LovePackages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.LoveService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("serviceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("serviceId");

                    b.ToTable("LoveServices");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("ReceiverId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("chatId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.HasIndex("UserId");

                    b.HasIndex("chatId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookingTimeAllowed")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<string>("adminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("adminId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("BookingPackageId")
                        .HasColumnType("int");

                    b.Property<int?>("BookingServiceId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayPalOrderId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookingPackageId")
                        .IsUnique()
                        .HasFilter("[BookingPackageId] IS NOT NULL");

                    b.HasIndex("BookingServiceId")
                        .IsUnique()
                        .HasFilter("[BookingServiceId] IS NOT NULL");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookingTimeAllowed")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("QuantityAvailable")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("categoryId")
                        .HasColumnType("int");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal?>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("serviceProviderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.HasIndex("serviceProviderId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ServiceProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ServiceProviders");
                });

            modelBuilder.Entity("Travel_Website_System_API_.Models.PackageService", b =>
                {
                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("PackageId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("PackageService");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Admin", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Admin")
                        .HasForeignKey("Travel_Website_System_API.Models.Admin", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ApplicationUser", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingPackage", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("Travel_Website_System_API.Models.Package", "package")
                        .WithMany("BookingPackages")
                        .HasForeignKey("packageId");

                    b.Navigation("client");

                    b.Navigation("package");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingService", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("Travel_Website_System_API.Models.Service", "service")
                        .WithMany("BookingServices")
                        .HasForeignKey("serviceId");

                    b.Navigation("client");

                    b.Navigation("service");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Chat", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Client", "client")
                        .WithOne("Chat")
                        .HasForeignKey("Travel_Website_System_API.Models.Chat", "clientId");

                    b.HasOne("Travel_Website_System_API.Models.CustomerService", "customerService")
                        .WithMany("Chats")
                        .HasForeignKey("customerServiceId");

                    b.Navigation("client");

                    b.Navigation("customerService");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Client", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("client")
                        .HasForeignKey("Travel_Website_System_API.Models.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.CustomerService", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("customerService")
                        .HasForeignKey("Travel_Website_System_API.Models.CustomerService", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.LovePackage", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("Travel_Website_System_API.Models.Package", "package")
                        .WithMany("LovePackages")
                        .HasForeignKey("packageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("package");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.LoveService", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientId");

                    b.HasOne("Travel_Website_System_API.Models.Service", "service")
                        .WithMany("LoveServices")
                        .HasForeignKey("serviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("service");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Message", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "Receiver")
                        .WithMany()
                        .HasForeignKey("ReceiverId");

                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.HasOne("Travel_Website_System_API.Models.ApplicationUser", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId");

                    b.HasOne("Travel_Website_System_API.Models.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("chatId");

                    b.Navigation("Chat");

                    b.Navigation("Receiver");

                    b.Navigation("Sender");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Package", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Admin", "admin")
                        .WithMany("Packages")
                        .HasForeignKey("adminId");

                    b.Navigation("admin");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Payment", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.BookingPackage", "BookingPackage")
                        .WithOne("Payment")
                        .HasForeignKey("Travel_Website_System_API.Models.Payment", "BookingPackageId");

                    b.HasOne("Travel_Website_System_API.Models.BookingService", "BookingService")
                        .WithOne("Payment")
                        .HasForeignKey("Travel_Website_System_API.Models.Payment", "BookingServiceId");

                    b.Navigation("BookingPackage");

                    b.Navigation("BookingService");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Service", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Category", "category")
                        .WithMany("Services")
                        .HasForeignKey("categoryId");

                    b.HasOne("Travel_Website_System_API.Models.ServiceProvider", "serviceProvider")
                        .WithMany("Services")
                        .HasForeignKey("serviceProviderId");

                    b.Navigation("category");

                    b.Navigation("serviceProvider");
                });

            modelBuilder.Entity("Travel_Website_System_API_.Models.PackageService", b =>
                {
                    b.HasOne("Travel_Website_System_API.Models.Package", "Package")
                        .WithMany("PackageServices")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Travel_Website_System_API.Models.Service", "Service")
                        .WithMany("PackageServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Package");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Admin", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ApplicationUser", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Messages");

                    b.Navigation("client");

                    b.Navigation("customerService");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingPackage", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.BookingService", b =>
                {
                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Category", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Client", b =>
                {
                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.CustomerService", b =>
                {
                    b.Navigation("Chats");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Package", b =>
                {
                    b.Navigation("BookingPackages");

                    b.Navigation("LovePackages");

                    b.Navigation("PackageServices");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.Service", b =>
                {
                    b.Navigation("BookingServices");

                    b.Navigation("LoveServices");

                    b.Navigation("PackageServices");
                });

            modelBuilder.Entity("Travel_Website_System_API.Models.ServiceProvider", b =>
                {
                    b.Navigation("Services");
                });
#pragma warning restore 612, 618
        }
    }
}
