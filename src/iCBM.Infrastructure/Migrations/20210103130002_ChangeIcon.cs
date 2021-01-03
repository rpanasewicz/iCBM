using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class ChangeIcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                column: "Icon",
                value: "store");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                column: "Icon",
                value: "store");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                column: "Icon",
                value: "store");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                column: "Icon",
                value: "shop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                column: "Icon",
                value: "shop");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                column: "Icon",
                value: "shop");
        }
    }
}
