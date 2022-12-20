using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_courses_CourseId",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_CourseId",
                table: "students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "students");

            migrationBuilder.AddColumn<string>(
                name: "Coursess",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coursess",
                table: "students");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_students_CourseId",
                table: "students",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_courses_CourseId",
                table: "students",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
