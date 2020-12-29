using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class ChangeEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                column: "Email",
                value: "user@example.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                column: "Email",
                value: "harry@example.com");
        }
    }
}
