using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class AddNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 11, 30, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("3a4d56e5-c062-4484-92d9-4a2347eaf809"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 8, 31, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2022, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc), new DateTime(2021, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Body", "CreatedBy", "CreatedOn", "ExpirationDate", "IsDeleted", "ModifiedBy", "ModifiedOn", "PublishDated", "Title" },
                values: new object[] { new Guid("622df3c9-812b-4e4f-bdff-91193d61149a"), "Thanks for joining.", "System", new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), null, false, "System", new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), "Hello, welcome to iCBM" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc), new DateTime(2019, 12, 31, 23, 0, 0, 0, DateTimeKind.Utc) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("622df3c9-812b-4e4f-bdff-91193d61149a"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("3a4d56e5-c062-4484-92d9-4a2347eaf809"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ConstructionStages",
                keyColumn: "Id",
                keyValue: new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"),
                columns: new[] { "CreatedOn", "ModifiedOn", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"),
                columns: new[] { "CreatedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
