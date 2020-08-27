using Microsoft.EntityFrameworkCore.Migrations;

namespace TagemEgitim.Migrations
{
    public partial class mig04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ülkeler_ülkeID",
                table: "Kişiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ünvanlar_ünvanID",
                table: "Kişiler");

            migrationBuilder.AlterColumn<int>(
                name: "ünvanID",
                table: "Kişiler",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ülkeID",
                table: "Kişiler",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ülkeler_ülkeID",
                table: "Kişiler");

            migrationBuilder.DropForeignKey(
                name: "FK_Kişiler_Ünvanlar_ünvanID",
                table: "Kişiler");

            migrationBuilder.AlterColumn<int>(
                name: "ünvanID",
                table: "Kişiler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ülkeID",
                table: "Kişiler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Kişiler_Ülkeler_ülkeID",
                table: "Kişiler",
                column: "ülkeID",
                principalTable: "Ülkeler",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Kişiler_Ünvanlar_ünvanID",
                table: "Kişiler",
                column: "ünvanID",
                principalTable: "Ünvanlar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
