using Microsoft.EntityFrameworkCore.Migrations;

namespace TagemEgitim.Migrations
{
    public partial class mig03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obscures_Kurslar_KursID",
                table: "Obscures");

            migrationBuilder.DropColumn(
                name: "kursSuresi",
                table: "Kurslar");

            migrationBuilder.RenameColumn(
                name: "KursID",
                table: "Obscures",
                newName: "kursID");

            migrationBuilder.RenameIndex(
                name: "IX_Obscures_KursID",
                table: "Obscures",
                newName: "IX_Obscures_kursID");

            migrationBuilder.AlterColumn<int>(
                name: "kursID",
                table: "Obscures",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Obscures_Kurslar_kursID",
                table: "Obscures",
                column: "kursID",
                principalTable: "Kurslar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Obscures_Kurslar_kursID",
                table: "Obscures");

            migrationBuilder.RenameColumn(
                name: "kursID",
                table: "Obscures",
                newName: "KursID");

            migrationBuilder.RenameIndex(
                name: "IX_Obscures_kursID",
                table: "Obscures",
                newName: "IX_Obscures_KursID");

            migrationBuilder.AlterColumn<int>(
                name: "KursID",
                table: "Obscures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "kursSuresi",
                table: "Kurslar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Obscures_Kurslar_KursID",
                table: "Obscures",
                column: "KursID",
                principalTable: "Kurslar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
