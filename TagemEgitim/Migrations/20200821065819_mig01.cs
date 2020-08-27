using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TagemEgitim.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kulname = table.Column<string>(maxLength: 120, nullable: false),
                    kulpass = table.Column<string>(maxLength: 12, nullable: true),
                    kulpassEnc = table.Column<string>(maxLength: 600, nullable: true),
                    hatirla = table.Column<bool>(nullable: false),
                    cerez = table.Column<string>(maxLength: 60, nullable: true),
                    cerezEnc = table.Column<string>(maxLength: 600, nullable: true),
                    hatali = table.Column<int>(nullable: false),
                    kilitliTarih = table.Column<DateTime>(nullable: false),
                    admin = table.Column<bool>(nullable: false),
                    adminCode = table.Column<string>(maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kurslar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(nullable: true),
                    isimEN = table.Column<string>(nullable: true),
                    tarihBasla = table.Column<DateTime>(nullable: false),
                    tarihBitis = table.Column<DateTime>(nullable: false),
                    basvuruBaslama = table.Column<DateTime>(nullable: false),
                    basvuruBitis = table.Column<DateTime>(nullable: false),
                    kursSuresi = table.Column<int>(nullable: false),
                    basvuruSuresi = table.Column<int>(nullable: false),
                    basvuruDuraklat = table.Column<bool>(nullable: false),
                    notlar = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurslar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ülkeler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ülkeler", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ünvanlar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ünvanlar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Obscures",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(nullable: true),
                    sayı = table.Column<int>(nullable: false),
                    KursID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obscures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Obscures_Kurslar_KursID",
                        column: x => x.KursID,
                        principalTable: "Kurslar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kişiler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isim = table.Column<string>(nullable: true),
                    soyisim = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    email2 = table.Column<string>(nullable: true),
                    cinsiyet = table.Column<int>(nullable: false),
                    doğumTarihi = table.Column<DateTime>(nullable: false),
                    ülkeID = table.Column<int>(nullable: true),
                    ünvanID = table.Column<int>(nullable: true),
                    kurum = table.Column<string>(nullable: true),
                    görev = table.Column<string>(nullable: true),
                    adres = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    telefon2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kişiler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kişiler_Ülkeler_ülkeID",
                        column: x => x.ülkeID,
                        principalTable: "Ülkeler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kişiler_Ünvanlar_ünvanID",
                        column: x => x.ünvanID,
                        principalTable: "Ünvanlar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "kişikurs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kişiID = table.Column<int>(nullable: false),
                    kursID = table.Column<int>(nullable: false),
                    katılımŞekli = table.Column<int>(nullable: false),
                    diğerKatılım = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kişikurs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kişikurs_Kişiler_kişiID",
                        column: x => x.kişiID,
                        principalTable: "Kişiler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kişikurs_Kurslar_kursID",
                        column: x => x.kursID,
                        principalTable: "Kurslar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_kişikurs_kişiID",
                table: "kişikurs",
                column: "kişiID");

            migrationBuilder.CreateIndex(
                name: "IX_kişikurs_kursID",
                table: "kişikurs",
                column: "kursID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_ülkeID",
                table: "Kişiler",
                column: "ülkeID");

            migrationBuilder.CreateIndex(
                name: "IX_Kişiler_ünvanID",
                table: "Kişiler",
                column: "ünvanID");

            migrationBuilder.CreateIndex(
                name: "IX_Obscures_KursID",
                table: "Obscures",
                column: "KursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kişikurs");

            migrationBuilder.DropTable(
                name: "Kullar");

            migrationBuilder.DropTable(
                name: "Obscures");

            migrationBuilder.DropTable(
                name: "Kişiler");

            migrationBuilder.DropTable(
                name: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ülkeler");

            migrationBuilder.DropTable(
                name: "Ünvanlar");
        }
    }
}
