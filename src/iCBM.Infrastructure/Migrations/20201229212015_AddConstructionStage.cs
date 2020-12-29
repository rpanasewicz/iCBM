using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iCBM.Infrastructure.Migrations
{
    public partial class AddConstructionStage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConstructionStageId",
                table: "Expenses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ConstructionStages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedFinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualFinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstructionStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstructionStages_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConstructionStages",
                columns: new[] { "Id", "ActualFinishDate", "ActualStartDate", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new Guid("3a4d56e5-c062-4484-92d9-4a2347eaf809"), null, null, 6, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "house", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSO", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ConstructionStages",
                columns: new[] { "Id", "ActualFinishDate", "ActualStartDate", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new Guid("0a7bc129-c7d5-401c-864c-6f23aabd5f10"), null, null, 6, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "house", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SSZ", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "ConstructionStages",
                columns: new[] { "Id", "ActualFinishDate", "ActualStartDate", "ColorId", "CreatedBy", "CreatedOn", "Icon", "IsDeleted", "ModifiedBy", "ModifiedOn", "Name", "OwnerId", "PlannedFinishDate", "PlannedStartDate" },
                values: new object[] { new Guid("68880b0e-cd7d-44b3-ba87-11c8904af433"), null, null, 6, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "house", false, "System", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finishing", new Guid("af76108b-11ee-448b-907f-0dcaccc8adf6"), new DateTime(2022, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ConstructionStageId",
                table: "Expenses",
                column: "ConstructionStageId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstructionStages_OwnerId",
                table: "ConstructionStages",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ConstructionStages_ConstructionStageId",
                table: "Expenses",
                column: "ConstructionStageId",
                principalTable: "ConstructionStages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ConstructionStages_ConstructionStageId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "ConstructionStages");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ConstructionStageId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ConstructionStageId",
                table: "Expenses");
        }
    }
}
