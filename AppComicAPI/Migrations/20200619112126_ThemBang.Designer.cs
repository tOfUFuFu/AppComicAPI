﻿// <auto-generated />
using System;
using AppDocTruyenAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppComicAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200619112126_ThemBang")]
    partial class ThemBang
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppComicAPI.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaTruyen")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenChuong")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("MaTruyen");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("AppComicAPI.Models.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaChapter")
                        .HasColumnType("int");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MaChapter");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("AppComicAPI.Models.TaiKhoan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHienThi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaiKhoans");
                });

            modelBuilder.Entity("AppComicAPI.Models.TheLoai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("TenTheLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TheLoais");
                });

            modelBuilder.Entity("AppComicAPI.Models.TheLoaiTruyen", b =>
                {
                    b.Property<int>("MaTheLoai")
                        .HasColumnType("int");

                    b.Property<int>("MaTruyen")
                        .HasColumnType("int");

                    b.HasKey("MaTheLoai", "MaTruyen");

                    b.HasIndex("MaTruyen");

                    b.ToTable("TheLoaiTruyens");
                });

            modelBuilder.Entity("AppComicAPI.Models.Truyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Like")
                        .HasColumnType("int");

                    b.Property<int>("MaTaiKhoanDang")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenTruyen")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("MaTaiKhoanDang");

                    b.ToTable("Truyens");
                });

            modelBuilder.Entity("AppComicAPI.Models.TruyenYeuThich", b =>
                {
                    b.Property<int>("MaTaiKhoan")
                        .HasColumnType("int");

                    b.Property<int>("MaTruyen")
                        .HasColumnType("int");

                    b.HasKey("MaTaiKhoan", "MaTruyen");

                    b.HasIndex("MaTruyen");

                    b.ToTable("TruyenYeuThichs");
                });

            modelBuilder.Entity("AppComicAPI.Models.Chapter", b =>
                {
                    b.HasOne("AppComicAPI.Models.Truyen", "Truyen")
                        .WithMany()
                        .HasForeignKey("MaTruyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppComicAPI.Models.Page", b =>
                {
                    b.HasOne("AppComicAPI.Models.Chapter", "Chapter")
                        .WithMany()
                        .HasForeignKey("MaChapter")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppComicAPI.Models.TheLoaiTruyen", b =>
                {
                    b.HasOne("AppComicAPI.Models.TheLoai", "TheLoai")
                        .WithMany("TheLoaiTruyens")
                        .HasForeignKey("MaTheLoai")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppComicAPI.Models.Truyen", "Truyen")
                        .WithMany("TheLoaiTruyens")
                        .HasForeignKey("MaTruyen")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppComicAPI.Models.Truyen", b =>
                {
                    b.HasOne("AppComicAPI.Models.TaiKhoan", "TaiKhoan")
                        .WithMany()
                        .HasForeignKey("MaTaiKhoanDang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppComicAPI.Models.TruyenYeuThich", b =>
                {
                    b.HasOne("AppComicAPI.Models.TaiKhoan", "TaiKhoan")
                        .WithMany("TruyenYeuThichs")
                        .HasForeignKey("MaTaiKhoan")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AppComicAPI.Models.Truyen", "Truyen")
                        .WithMany("TruyenYeuThichs")
                        .HasForeignKey("MaTruyen")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
