using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIAPPOSTECH_FASE2.Infra.Migrations
{
    public partial class Add_Salt_Usuario_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "SaltHash",
                table: "Usuario",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Noticia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Noticia_UsuarioId",
                table: "Noticia",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Noticia_Usuario_UsuarioId",
                table: "Noticia",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Noticia_Usuario_UsuarioId",
                table: "Noticia");

            migrationBuilder.DropIndex(
                name: "IX_Noticia_UsuarioId",
                table: "Noticia");

            migrationBuilder.DropColumn(
                name: "SaltHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Noticia");
        }
    }
}
