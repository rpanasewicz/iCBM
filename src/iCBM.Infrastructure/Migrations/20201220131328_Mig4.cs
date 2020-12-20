using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class Mig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Expenses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Expenses",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount_CurrencyId",
                table: "Expenses",
                type: "int",
                nullable: true);

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

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 8, "ALL" },
                    { 800, "UGX" },
                    { 807, "MKD" },
                    { 818, "EGP" },
                    { 826, "GBP" },
                    { 834, "TZS" },
                    { 840, "USD" },
                    { 858, "UYU" },
                    { 860, "UZS" },
                    { 788, "TND" },
                    { 882, "WST" },
                    { 901, "TWD" },
                    { 927, "UYW" },
                    { 928, "VES" },
                    { 929, "MRU" },
                    { 930, "STN" },
                    { 931, "CUC" },
                    { 932, "ZWL" },
                    { 933, "BYN" },
                    { 886, "YER" },
                    { 784, "AED" },
                    { 780, "TTD" },
                    { 776, "TOP" },
                    { 604, "PEN" },
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
                    { 706, "SOS" },
                    { 710, "ZAR" },
                    { 728, "SSP" },
                    { 748, "SZL" },
                    { 752, "SEK" },
                    { 756, "CHF" },
                    { 760, "SYP" },
                    { 764, "THB" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 934, "TMT" },
                    { 600, "PYG" },
                    { 936, "GHS" },
                    { 940, "UYI" },
                    { 968, "SRD" },
                    { 969, "MGA" },
                    { 970, "COU" },
                    { 971, "AFN" },
                    { 972, "TJS" },
                    { 973, "AOA" },
                    { 975, "BGN" },
                    { 976, "CDF" },
                    { 967, "ZMW" },
                    { 977, "BAM" },
                    { 979, "MXV" },
                    { 980, "UAH" },
                    { 981, "GEL" },
                    { 984, "BOV" },
                    { 985, "PLN" },
                    { 986, "BRL" },
                    { 990, "CLF" },
                    { 994, "XSU" },
                    { 978, "EUR" },
                    { 965, "XUA" },
                    { 964, "XPD" },
                    { 963, "XTS" },
                    { 941, "RSD" },
                    { 943, "MZN" },
                    { 944, "AZN" },
                    { 946, "RON" },
                    { 947, "CHE" },
                    { 948, "CHW" },
                    { 949, "TRY" },
                    { 950, "XAF" },
                    { 951, "XCD" },
                    { 952, "XOF" },
                    { 953, "XPF" },
                    { 955, "XBA" },
                    { 956, "XBB" },
                    { 957, "XBC" },
                    { 958, "XBD" },
                    { 959, "XAU" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 960, "XDR" },
                    { 961, "XAG" },
                    { 962, "XPT" },
                    { 938, "SDG" },
                    { 997, "USN" },
                    { 598, "PGK" },
                    { 586, "PKR" },
                    { 156, "CNY" },
                    { 170, "COP" },
                    { 174, "KMF" },
                    { 188, "CRC" },
                    { 191, "HRK" },
                    { 192, "CUP" },
                    { 203, "CZK" },
                    { 208, "DKK" },
                    { 152, "CLP" },
                    { 214, "DOP" },
                    { 230, "ETB" },
                    { 232, "ERN" },
                    { 238, "FKP" },
                    { 242, "FJD" },
                    { 262, "DJF" },
                    { 270, "GMD" },
                    { 292, "GIP" },
                    { 320, "GTQ" },
                    { 222, "SVC" },
                    { 144, "LKR" },
                    { 136, "KYD" },
                    { 132, "CVE" },
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
                    { 84, "BZD" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 90, "SBD" },
                    { 96, "BND" },
                    { 104, "MMK" },
                    { 108, "BIF" },
                    { 116, "KHR" },
                    { 124, "CAD" },
                    { 324, "GNF" },
                    { 590, "PAB" },
                    { 328, "GYD" },
                    { 340, "HNL" },
                    { 454, "MWK" },
                    { 458, "MYR" },
                    { 462, "MVR" },
                    { 480, "MUR" },
                    { 484, "MXN" },
                    { 496, "MNT" },
                    { 498, "MDL" },
                    { 504, "MAD" },
                    { 446, "MOP" },
                    { 512, "OMR" },
                    { 524, "NPR" },
                    { 532, "ANG" },
                    { 533, "AWG" },
                    { 548, "VUV" },
                    { 554, "NZD" },
                    { 558, "NIO" },
                    { 566, "NGN" },
                    { 578, "NOK" },
                    { 516, "NAD" },
                    { 434, "LYD" },
                    { 430, "LRD" },
                    { 426, "LSL" },
                    { 344, "HKD" },
                    { 348, "HUF" },
                    { 352, "ISK" },
                    { 356, "INR" },
                    { 360, "IDR" },
                    { 364, "IRR" },
                    { 368, "IQD" },
                    { 376, "ILS" },
                    { 388, "JMD" },
                    { 392, "JPY" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 398, "KZT" },
                    { 400, "JOD" },
                    { 404, "KES" },
                    { 408, "KPW" },
                    { 410, "KRW" },
                    { 414, "KWD" },
                    { 417, "KGS" },
                    { 418, "LAK" },
                    { 422, "LBP" },
                    { 332, "HTG" },
                    { 999, "XXX" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropColumn(
                name: "Amount_CurrencyId",
                table: "Expenses");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);
        }
    }
}
