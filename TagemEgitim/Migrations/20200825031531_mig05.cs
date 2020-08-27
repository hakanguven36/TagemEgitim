using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TagemEgitim.Migrations
{
    public partial class mig05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_kişikurs_Kişiler_kişiID",
                table: "kişikurs");

            migrationBuilder.DropForeignKey(
                name: "FK_kişikurs_Kurslar_kursID",
                table: "kişikurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ülkeler_ülkeID",
                table: "Kişiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ünvanlar_ünvanID",
                table: "Kişiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Obscures_Kurslar_kursID",
                table: "Obscures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ünvanlar",
                table: "Ünvanlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ülkeler",
                table: "Ülkeler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Obscures",
                table: "Obscures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kurslar",
                table: "Kurslar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kişiler",
                table: "Kişiler");

            migrationBuilder.DropColumn(
                name: "diğerKatılım",
                table: "kişikurs");

            migrationBuilder.DropColumn(
                name: "basvuruBaslama",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "basvuruBitis",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "basvuruDuraklat",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "basvuruSuresi",
                table: "Kurslar");

            migrationBuilder.RenameTable(
                name: "Ünvanlar",
                newName: "Unvan");

            migrationBuilder.RenameTable(
                name: "Ülkeler",
                newName: "Ulke");

            migrationBuilder.RenameTable(
                name: "Obscures",
                newName: "Obscure");

            migrationBuilder.RenameTable(
                name: "Kurslar",
                newName: "Kurs");

            migrationBuilder.RenameTable(
                name: "Kişiler",
                newName: "Kisi");

            migrationBuilder.RenameIndex(
                name: "IX_Obscures_kursID",
                table: "Obscure",
                newName: "IX_Obscure_kursID");

            migrationBuilder.RenameIndex(
                name: "IX_Kişiler_ünvanID",
                table: "Kisi",
                newName: "IX_Kisi_ünvanID");

            migrationBuilder.RenameIndex(
                name: "IX_Kişiler_ülkeID",
                table: "Kisi",
                newName: "IX_Kisi_ülkeID");

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Unvan",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Ulke",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Obscure",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "notlar",
                table: "Kurs",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isimEN",
                table: "Kurs",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Kurs",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefon2",
                table: "Kisi",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefon",
                table: "Kisi",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "soyisim",
                table: "Kisi",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "kurum",
                table: "Kisi",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Kisi",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "görev",
                table: "Kisi",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email2",
                table: "Kisi",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Kisi",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adres",
                table: "Kisi",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unvan",
                table: "Unvan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obscure",
                table: "Obscure",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kurs",
                table: "Kurs",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kisi",
                table: "Kisi",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kisi_Ulke_ülkeID",
                table: "Kisi",
                column: "ülkeID",
                principalTable: "Ulke",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kisi_Unvan_ünvanID",
                table: "Kisi",
                column: "ünvanID",
                principalTable: "Unvan",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kişikurs_Kisi_kişiID",
                table: "kişikurs",
                column: "kişiID",
                principalTable: "Kisi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kişikurs_Kurs_kursID",
                table: "kişikurs",
                column: "kursID",
                principalTable: "Kurs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obscure_Kurs_kursID",
                table: "Obscure",
                column: "kursID",
                principalTable: "Kurs",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kisi_Ulke_ülkeID",
                table: "Kisi");

            migrationBuilder.DropForeignKey(
                name: "FK_Kisi_Unvan_ünvanID",
                table: "Kisi");

            migrationBuilder.DropForeignKey(
                name: "FK_kişikurs_Kisi_kişiID",
                table: "kişikurs");

            migrationBuilder.DropForeignKey(
                name: "FK_kişikurs_Kurs_kursID",
                table: "kişikurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Obscure_Kurs_kursID",
                table: "Obscure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unvan",
                table: "Unvan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ulke",
                table: "Ulke");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Obscure",
                table: "Obscure");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kurs",
                table: "Kurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Kisi",
                table: "Kisi");

            migrationBuilder.RenameTable(
                name: "Unvan",
                newName: "Ünvanlar");

            migrationBuilder.RenameTable(
                name: "Ulke",
                newName: "Ülkeler");

            migrationBuilder.RenameTable(
                name: "Obscure",
                newName: "Obscures");

            migrationBuilder.RenameTable(
                name: "Kurs",
                newName: "Kurslar");

            migrationBuilder.RenameTable(
                name: "Kisi",
                newName: "Kişiler");

            migrationBuilder.RenameIndex(
                name: "IX_Obscure_kursID",
                table: "Obscures",
                newName: "IX_Obscures_kursID");

            migrationBuilder.RenameIndex(
                name: "IX_Kisi_ünvanID",
                table: "Kişiler",
                newName: "IX_Kişiler_ünvanID");

            migrationBuilder.RenameIndex(
                name: "IX_Kisi_ülkeID",
                table: "Kişiler",
                newName: "IX_Kişiler_ülkeID");

            migrationBuilder.AddColumn<string>(
                name: "diğerKatılım",
                table: "kişikurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Ünvanlar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Ülkeler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Obscures",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "notlar",
                table: "Kurslar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isimEN",
                table: "Kurslar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Kurslar",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AddColumn<DateTime>(
                name: "basvuruBaslama",
                table: "Kurslar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "basvuruBitis",
                table: "Kurslar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "basvuruDuraklat",
                table: "Kurslar",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "basvuruSuresi",
                table: "Kurslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "telefon2",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefon",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "soyisim",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "kurum",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "isim",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "görev",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email2",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "adres",
                table: "Kişiler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ünvanlar",
                table: "Ünvanlar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ülkeler",
                table: "Ülkeler",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Obscures",
                table: "Obscures",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kurslar",
                table: "Kurslar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Kişiler",
                table: "Kişiler",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_kişikurs_Kişiler_kişiID",
                table: "kişikurs",
                column: "kişiID",
                principalTable: "Kişiler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_kişikurs_Kurslar_kursID",
                table: "kişikurs",
                column: "kursID",
                principalTable: "Kurslar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kişiler_Ülkeler_ülkeID",
                table: "Kişiler",
                column: "ülkeID",
                principalTable: "Ülkeler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kişiler_Ünvanlar_ünvanID",
                table: "Kişiler",
                column: "ünvanID",
                principalTable: "Ünvanlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Obscures_Kurslar_kursID",
                table: "Obscures",
                column: "kursID",
                principalTable: "Kurslar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
