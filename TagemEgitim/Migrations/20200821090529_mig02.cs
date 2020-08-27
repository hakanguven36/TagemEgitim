using Microsoft.EntityFrameworkCore.Migrations;

namespace TagemEgitim.Migrations
{
    public partial class mig02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "evtürü",
                table: "Kurslar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "toplantıtürü",
                table: "Kurslar",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ulustürü",
                table: "Kurslar",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "evtürü",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "toplantıtürü",
                table: "Kurslar");

            migrationBuilder.DropColumn(
                name: "ulustürü",
                table: "Kurslar");
        }
    }
}
