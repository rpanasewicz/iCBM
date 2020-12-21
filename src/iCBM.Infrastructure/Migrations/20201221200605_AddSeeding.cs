using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace iCBM.Infrastructure.Migrations
{
    public partial class AddSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Colors_ColorId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ColorId",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "ExpirationDate", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"), 6, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shop", "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Materials" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "ExpirationDate", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"), 1, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shop", "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Services" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "ExpirationDate", "Icon", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[] { new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"), 13, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "shop", "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ColorId",
                table: "Categories",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Colors_ColorId",
                table: "Categories",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
