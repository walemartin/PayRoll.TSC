﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PayRoll.TSC.Data;

#nullable disable

namespace PayRoll.TSC.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
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

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

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
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PayRoll.TSC.Data.NavigationMenu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControllerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("ExternalUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsExternal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentMenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ParentMenuId");

                    b.ToTable("AspNetNavigationMenu");
                });

            modelBuilder.Entity("PayRoll.TSC.Data.RoleMenuPermission", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("NavigationMenuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "NavigationMenuId");

                    b.HasIndex("NavigationMenuId");

                    b.ToTable("AspNetRoleMenuPermission");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.AccountType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("AccountType");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.BankBranch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("BankBranch");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.JobTitle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("JobTitle");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.MaritalStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MaritalStatus");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Nationality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Nationality");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.PaymentMode", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("PaymentMode");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.SalaryGrade", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SalaryGrade");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.StaffProfile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AccountTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<decimal>("AnnualBasicSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BankBranchID")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Currency")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FirstAppointment")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<int?>("IsActive")
                        .HasColumnType("int");

                    b.Property<int?>("JobTitleID")
                        .HasColumnType("int");

                    b.Property<string>("MaidenName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("MaritalStatusID")
                        .HasColumnType("int");

                    b.Property<int?>("NationalityID")
                        .HasColumnType("int");

                    b.Property<short>("NoOfChildren")
                        .HasColumnType("smallint");

                    b.Property<string>("OtherName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("PaymentModeID")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("ProbationPeriod")
                        .HasColumnType("smallint");

                    b.Property<int?>("SalaryGradeID")
                        .HasColumnType("int");

                    b.Property<string>("StaffNo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("StateOfOriginID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TitleID")
                        .HasColumnType("int");

                    b.Property<bool?>("TransportAllowance")
                        .HasColumnType("bit");

                    b.Property<string>("TrxnID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("AccountTypeID");

                    b.HasIndex("BankBranchID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("JobTitleID");

                    b.HasIndex("MaritalStatusID");

                    b.HasIndex("NationalityID");

                    b.HasIndex("PaymentModeID");

                    b.HasIndex("SalaryGradeID");

                    b.HasIndex("StateOfOriginID");

                    b.HasIndex("TitleID");

                    b.ToTable("StaffProfile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.StateOfOrigin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("StateOfOrigin");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Title", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Title");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PayRoll.TSC.Data.NavigationMenu", b =>
                {
                    b.HasOne("PayRoll.TSC.Data.NavigationMenu", "ParentNavigationMenu")
                        .WithMany()
                        .HasForeignKey("ParentMenuId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("ParentNavigationMenu");
                });

            modelBuilder.Entity("PayRoll.TSC.Data.RoleMenuPermission", b =>
                {
                    b.HasOne("PayRoll.TSC.Data.NavigationMenu", "NavigationMenu")
                        .WithMany()
                        .HasForeignKey("NavigationMenuId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("NavigationMenu");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.StaffProfile", b =>
                {
                    b.HasOne("PayRoll.TSC.PayRollModel.AccountType", "AccountType")
                        .WithMany("Staffprofile")
                        .HasForeignKey("AccountTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.BankBranch", "BankBranch")
                        .WithMany("Staffprofile")
                        .HasForeignKey("BankBranchID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.Department", "Department")
                        .WithMany("Staffprofile")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.JobTitle", "JobTitle")
                        .WithMany("Staffprofile")
                        .HasForeignKey("JobTitleID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.MaritalStatus", "MaritalStatus")
                        .WithMany("Staffprofile")
                        .HasForeignKey("MaritalStatusID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.Nationality", "Nationality")
                        .WithMany("Staffprofile")
                        .HasForeignKey("NationalityID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.PaymentMode", "PaymentMode")
                        .WithMany("Staffprofile")
                        .HasForeignKey("PaymentModeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.SalaryGrade", "SalaryGrade")
                        .WithMany("Staffprofile")
                        .HasForeignKey("SalaryGradeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.StateOfOrigin", "StateOfOrigin")
                        .WithMany("Staffprofile")
                        .HasForeignKey("StateOfOriginID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("PayRoll.TSC.PayRollModel.Title", "Title")
                        .WithMany("Staffprofile")
                        .HasForeignKey("TitleID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("AccountType");

                    b.Navigation("BankBranch");

                    b.Navigation("Department");

                    b.Navigation("JobTitle");

                    b.Navigation("MaritalStatus");

                    b.Navigation("Nationality");

                    b.Navigation("PaymentMode");

                    b.Navigation("SalaryGrade");

                    b.Navigation("StateOfOrigin");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.AccountType", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.BankBranch", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Department", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.JobTitle", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.MaritalStatus", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Nationality", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.PaymentMode", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.SalaryGrade", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.StateOfOrigin", b =>
                {
                    b.Navigation("Staffprofile");
                });

            modelBuilder.Entity("PayRoll.TSC.PayRollModel.Title", b =>
                {
                    b.Navigation("Staffprofile");
                });
#pragma warning restore 612, 618
        }
    }
}
