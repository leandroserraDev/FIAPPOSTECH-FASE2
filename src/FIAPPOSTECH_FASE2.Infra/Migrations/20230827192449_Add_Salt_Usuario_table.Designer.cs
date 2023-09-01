﻿// <auto-generated />
using System;
using FIAPPOSTECH_FASE2.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FIAPPOSTECH_FASE2.Infra.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230827192449_Add_Salt_Usuario_table")]
    partial class Add_Salt_Usuario_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FIAPPOSTECH_FASE2.DOMAIN.Entities.Noticia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataPublicacao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Noticia", (string)null);
                });

            modelBuilder.Entity("FIAPPOSTECH_FASE2.DOMAIN.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)");

                    b.Property<byte[]>("SaltHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("FIAPPOSTECH_FASE2.DOMAIN.Entities.Noticia", b =>
                {
                    b.HasOne("FIAPPOSTECH_FASE2.DOMAIN.Entities.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FIAPPOSTECH_FASE2.DOMAIN.Entities.Usuario", null)
                        .WithMany("Noticias")
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("FIAPPOSTECH_FASE2.DOMAIN.Entities.Usuario", b =>
                {
                    b.Navigation("Noticias");
                });
#pragma warning restore 612, 618
        }
    }
}
