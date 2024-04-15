﻿// <auto-generated />
using System;
using Connect_agenda_data.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Connect_agenda_data.Migrations
{
    [DbContext(typeof(ConnectAgendaContext))]
    [Migration("20240305232019_add-user")]
    partial class adduser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Connect_agenda_models.Models.AddresModel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserCreateId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("UserUpdateId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("UserCreateId");

                    b.HasIndex("UserUpdateId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Connect_agenda_models.Models.UserModel", b =>
                {
                    b.Property<string>("UserCreateId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AddresId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Id")
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("UserCreateId");

                    b.HasIndex("AddresId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Connect_agenda_models.Models.AddresModel", b =>
                {
                    b.HasOne("Connect_agenda_models.Models.UserModel", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Connect_agenda_models.Models.UserModel", "UserUpdate")
                        .WithMany()
                        .HasForeignKey("UserUpdateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserCreate");

                    b.Navigation("UserUpdate");
                });

            modelBuilder.Entity("Connect_agenda_models.Models.UserModel", b =>
                {
                    b.HasOne("Connect_agenda_models.Models.AddresModel", "Addres")
                        .WithMany()
                        .HasForeignKey("AddresId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Connect_agenda_models.Models.UserModel", "UserCreate")
                        .WithMany()
                        .HasForeignKey("UserCreateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Addres");

                    b.Navigation("UserCreate");
                });
#pragma warning restore 612, 618
        }
    }
}
