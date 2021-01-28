using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class ChangeColors2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 3, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 5, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "gray");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "red");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "yellow");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "green");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "blue");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "indigo");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "purple");

            migrationBuilder.UpdateData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "pink");

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { 6, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 11, 30, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("3a4d56e5-c062-4484-92d9-4a2347eaf809"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { 4, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("622df3c9-812b-4e4f-bdff-91193d61149a"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PublishDated" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 5, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

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
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { 5, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 11, 30, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("3a4d56e5-c062-4484-92d9-4a2347eaf809"),
                columns: new[] { "ColorId", "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { 6, new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("622df3c9-812b-4e4f-bdff-91193d61149a"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PublishDated" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
