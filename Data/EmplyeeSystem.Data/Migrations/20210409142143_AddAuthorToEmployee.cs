using Microsoft.EntityFrameworkCore.Migrations;

namespace EmplyeeSystem.Data.Migrations
{
    public partial class AddAuthorToEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AuthorId",
                table: "Employees",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_AuthorId",
                table: "Employees",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_AuthorId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_AuthorId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Employees");
        }
    }
}
