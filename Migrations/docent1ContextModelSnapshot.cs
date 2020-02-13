﻿// <auto-generated />
using System;
using Fric_frac.Models.FricFrac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fric_frac.Migrations
{
    [DbContext(typeof(docent1Context))]
    partial class docent1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<string>("Desc")
                        .HasColumnType("varchar(256) CHARACTER SET utf8mb4")
                        .HasMaxLength(256);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1024)");

                    b.Property<DateTime?>("Ends")
                        .HasColumnType("datetime");

                    b.Property<int?>("EventcategoryId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("EventtopicId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("OrganiserDescription")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("OrganiserName")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<DateTime?>("Starts")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("EventcategoryId");

                    b.HasIndex("EventtopicId");

                    b.ToTable("event");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Eventcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("eventcategory");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Eventtopic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("eventtopic");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Address1")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address2")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("varchar(80)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone1")
                        .HasColumnType("varchar(25)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int(11)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int(11)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Salt")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("RoleId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Venue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Event", b =>
                {
                    b.HasOne("Fric_frac.Models.FricFrac.Eventcategory", "Eventcategory")
                        .WithMany()
                        .HasForeignKey("EventcategoryId");

                    b.HasOne("Fric_frac.Models.FricFrac.Eventtopic", "Eventtopic")
                        .WithMany()
                        .HasForeignKey("EventtopicId");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Person", b =>
                {
                    b.HasOne("Fric_frac.Models.FricFrac.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.User", b =>
                {
                    b.HasOne("Fric_frac.Models.FricFrac.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.HasOne("Fric_frac.Models.FricFrac.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Fric_frac.Models.FricFrac.Venue", b =>
                {
                    b.HasOne("Fric_frac.Models.FricFrac.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}