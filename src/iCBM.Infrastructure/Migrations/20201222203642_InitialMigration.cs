using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(248)", maxLength: 248, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(248)", maxLength: 248, nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    City = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(248)", maxLength: 248, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(38,2)", precision: 38, scale: 2, nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    ExpenseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "red" },
                    { 19, "grey" },
                    { 18, "blue-grey" },
                    { 17, "brown" },
                    { 16, "deep-orange" },
                    { 15, "orange" },
                    { 13, "yellow" },
                    { 12, "lime" },
                    { 11, "light-green" },
                    { 14, "amber" },
                    { 9, "teal" },
                    { 10, "green" },
                    { 3, "purple" },
                    { 4, "deep-purple" },
                    { 5, "indigo" },
                    { 2, "pink" },
                    { 7, "light-blue" },
                    { 8, "cyan" },
                    { 6, "blue" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 860, "UZS" },
                    { 800, "UGX" },
                    { 807, "MKD" },
                    { 818, "EGP" },
                    { 826, "GBP" },
                    { 834, "TZS" },
                    { 840, "USD" },
                    { 858, "UYU" },
                    { 882, "WST" },
                    { 933, "BYN" },
                    { 901, "TWD" },
                    { 927, "UYW" },
                    { 928, "VES" },
                    { 929, "MRU" },
                    { 930, "STN" },
                    { 931, "CUC" },
                    { 932, "ZWL" },
                    { 788, "TND" },
                    { 886, "YER" },
                    { 784, "AED" },
                    { 706, "SOS" },
                    { 776, "TOP" },
                    { 604, "PEN" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 608, "PHP" },
                    { 634, "QAR" },
                    { 643, "RUB" },
                    { 646, "RWF" },
                    { 654, "SHP" },
                    { 682, "SAR" },
                    { 690, "SCR" },
                    { 694, "SLL" },
                    { 702, "SGD" },
                    { 704, "VND" },
                    { 934, "TMT" },
                    { 710, "ZAR" },
                    { 728, "SSP" },
                    { 748, "SZL" },
                    { 752, "SEK" },
                    { 756, "CHF" },
                    { 760, "SYP" },
                    { 764, "THB" },
                    { 780, "TTD" },
                    { 936, "GHS" },
                    { 950, "XAF" },
                    { 940, "UYI" },
                    { 968, "SRD" },
                    { 969, "MGA" },
                    { 970, "COU" },
                    { 971, "AFN" },
                    { 972, "TJS" },
                    { 973, "AOA" },
                    { 975, "BGN" },
                    { 976, "CDF" },
                    { 977, "BAM" },
                    { 978, "EUR" },
                    { 979, "MXV" },
                    { 980, "UAH" },
                    { 981, "GEL" },
                    { 984, "BOV" },
                    { 985, "PLN" },
                    { 986, "BRL" },
                    { 990, "CLF" },
                    { 994, "XSU" },
                    { 997, "USN" },
                    { 967, "ZMW" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 938, "SDG" },
                    { 965, "XUA" },
                    { 963, "XTS" },
                    { 941, "RSD" },
                    { 943, "MZN" },
                    { 944, "AZN" },
                    { 946, "RON" },
                    { 947, "CHE" },
                    { 948, "CHW" },
                    { 949, "TRY" },
                    { 600, "PYG" },
                    { 951, "XCD" },
                    { 952, "XOF" },
                    { 953, "XPF" },
                    { 955, "XBA" },
                    { 956, "XBB" },
                    { 957, "XBC" },
                    { 958, "XBD" },
                    { 959, "XAU" },
                    { 960, "XDR" },
                    { 961, "XAG" },
                    { 962, "XPT" },
                    { 964, "XPD" },
                    { 598, "PGK" },
                    { 532, "ANG" },
                    { 586, "PKR" },
                    { 152, "CLP" },
                    { 156, "CNY" },
                    { 170, "COP" },
                    { 174, "KMF" },
                    { 188, "CRC" },
                    { 191, "HRK" },
                    { 192, "CUP" },
                    { 203, "CZK" },
                    { 144, "LKR" },
                    { 208, "DKK" },
                    { 222, "SVC" },
                    { 230, "ETB" },
                    { 232, "ERN" },
                    { 238, "FKP" },
                    { 242, "FJD" },
                    { 262, "DJF" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 270, "GMD" },
                    { 292, "GIP" },
                    { 214, "DOP" },
                    { 136, "KYD" },
                    { 132, "CVE" },
                    { 124, "CAD" },
                    { 8, "ALL" },
                    { 12, "DZD" },
                    { 32, "ARS" },
                    { 36, "AUD" },
                    { 44, "BSD" },
                    { 48, "BHD" },
                    { 50, "BDT" },
                    { 51, "AMD" },
                    { 52, "BBD" },
                    { 60, "BMD" },
                    { 64, "BTN" },
                    { 68, "BOB" },
                    { 72, "BWP" },
                    { 84, "BZD" },
                    { 90, "SBD" },
                    { 96, "BND" },
                    { 104, "MMK" },
                    { 108, "BIF" },
                    { 116, "KHR" },
                    { 320, "GTQ" },
                    { 324, "GNF" },
                    { 328, "GYD" },
                    { 332, "HTG" },
                    { 446, "MOP" },
                    { 454, "MWK" },
                    { 458, "MYR" },
                    { 462, "MVR" },
                    { 480, "MUR" },
                    { 484, "MXN" },
                    { 496, "MNT" },
                    { 498, "MDL" },
                    { 504, "MAD" },
                    { 512, "OMR" },
                    { 516, "NAD" },
                    { 524, "NPR" },
                    { 999, "XXX" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 533, "AWG" },
                    { 548, "VUV" },
                    { 554, "NZD" },
                    { 558, "NIO" },
                    { 566, "NGN" },
                    { 578, "NOK" },
                    { 434, "LYD" },
                    { 590, "PAB" },
                    { 430, "LRD" },
                    { 422, "LBP" },
                    { 340, "HNL" },
                    { 344, "HKD" },
                    { 348, "HUF" },
                    { 352, "ISK" },
                    { 356, "INR" },
                    { 360, "IDR" },
                    { 364, "IRR" },
                    { 368, "IQD" },
                    { 376, "ILS" },
                    { 388, "JMD" },
                    { 392, "JPY" },
                    { 398, "KZT" },
                    { 400, "JOD" },
                    { 404, "KES" },
                    { 408, "KPW" },
                    { 410, "KRW" },
                    { 414, "KWD" },
                    { 417, "KGS" },
                    { 418, "LAK" },
                    { 426, "LSL" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "FirstName", "IsDeleted", "LastName", "ModifiedBy", "ModifiedOn", "Password" },
                values: new object[] { new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"), "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "harry@example.com", "Harry", false, "Potter", "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEAgypWPs8S/vBidt0j/vANTzN25W/BkUbO/MhGadoWBpCcEhFvnJ5VUV+lPLHBQq/Q==" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[] { new Guid("fe9fac56-7230-4c16-81c0-be9b61fdc861"), 6, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shop", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Materials", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[] { new Guid("fd547340-199e-49be-88ed-3d7570ddaf4b"), 1, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shop", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Services", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId" },
                values: new object[] { new Guid("1c7fdef1-1db4-45be-9058-eeb22d80ed01"), 13, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shop", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6") });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_OwnerId",
                table: "Categories",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_OwnerId",
                table: "Expenses",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SupplierId",
                table: "Expenses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_OwnerId",
                table: "Suppliers",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
