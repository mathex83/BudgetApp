using Microsoft.EntityFrameworkCore.Migrations;

namespace BudgetApp.Data.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetOwners",
                columns: table => new
                {
                    BudgetOwnerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetOwnerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetOwners", x => x.BudgetOwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "MonthData",
                columns: table => new
                {
                    MonthDataID = table.Column<int>(type: "int", nullable: false),
                    MonthDataString = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthData", x => x.MonthDataID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "YearData",
                columns: table => new
                {
                    YearDataID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearData", x => x.YearDataID);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Bolig" },
                    { 2, "Forsikring" },
                    { 3, "Multimedier" },
                    { 4, "Transport" }
                });

            migrationBuilder.InsertData(
                table: "MonthData",
                columns: new[] { "MonthDataID", "MonthDataString" },
                values: new object[,]
                {
                    { 11, "Nov" },
                    { 10, "Okt" },
                    { 9, "Sep" },
                    { 8, "Aug" },
                    { 7, "Jul" },
                    { 12, "Dec" },
                    { 5, "Maj" },
                    { 4, "Apr" },
                    { 3, "Mar" },
                    { 2, "Feb" },
                    { 1, "Jan" },
                    { 6, "Jun" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeID", "TransactionTypeName" },
                values: new object[,]
                {
                    { 1, "Udgifter" },
                    { 2, "Indtægter" }
                });

            migrationBuilder.InsertData(
                table: "YearData",
                column: "YearDataID",
                values: new object[]
                {
                    2018,
                    2019,
                    2020,
                    2021,
                    2022,
                    2026,
                    2024,
                    2025,
                    2027,
                    2028,
                    2017,
                    2023,
                    2016,
                    2006,
                    2014,
                    2013,
                    2012,
                    2011,
                    2010,
                    2008,
                    2007,
                    2029,
                    2005,
                    2004
                });

            migrationBuilder.InsertData(
                table: "YearData",
                column: "YearDataID",
                values: new object[]
                {
                    2003,
                    2002,
                    2001,
                    2015,
                    2030
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetOwners");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "MonthData");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "YearData");
        }
    }
}
