using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class ChangeColors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                column: "ColorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                column: "ColorId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "primary");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "secondary");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "success");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "danger");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "warning");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "info");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "light");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "dark");

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                column: "ColorId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                column: "ColorId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                column: "ColorId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                column: "ColorId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "red");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "pink");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "purple");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "deep-purple");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "indigo");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "blue");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "light-blue");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "cyan");

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 9, "teal" },
                    { 18, "blue-grey" },
                    { 17, "brown" },
                    { 16, "deep-orange" },
                    { 15, "orange" },
                    { 14, "amber" },
                    { 13, "yellow" },
                    { 12, "lime" },
                    { 11, "light-green" },
                    { 10, "green" },
                    { 19, "grey" }
                });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                column: "ColorId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                column: "ColorId",
                value: 6);
        }
    }
}
