using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TaxReturnPolicy = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DDVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tax = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DDVs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    ddvId = table.Column<int>(nullable: false),
                    TaxPayerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_TaxPayers_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_DDVs_ddvId",
                        column: x => x.ddvId,
                        principalTable: "DDVs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "TaxReturnPolicy" },
                values: new object[,]
                {
                    { 1, "Macedonia", 0.14999999999999999 },
                    { 2, "USA", 0.050000000000000003 },
                    { 3, "Great Britain", 0.0050000000000000001 }
                });

            migrationBuilder.InsertData(
                table: "DDVs",
                columns: new[] { "Id", "Tax" },
                values: new object[,]
                {
                    { 1, 0.0 },
                    { 2, 0.050000000000000003 },
                    { 3, 0.17999999999999999 }
                });

            migrationBuilder.InsertData(
                table: "TaxPayers",
                columns: new[] { "Id", "CountryId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 1, "Petar", "Petrevski" },
                    { 2, 1, "Igor", "Igorovski" },
                    { 3, 1, "Kire", "Kocev" },
                    { 4, 1, "ALeksandar", "Aleksandrovski" },
                    { 5, 2, "Franklin", "Short" },
                    { 6, 2, "George", "Wilkerson" },
                    { 7, 2, "Kyle", "McBride" },
                    { 8, 2, "Joseph", "Hudkins" },
                    { 9, 3, "Ben", "Duncan" },
                    { 10, 3, "Anthony", "Marshall" },
                    { 11, 3, "Jordan", "Murray" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_TaxPayerId",
                table: "Product",
                column: "TaxPayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ddvId",
                table: "Product",
                column: "ddvId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayers_CountryId",
                table: "TaxPayers",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TaxPayers");

            migrationBuilder.DropTable(
                name: "DDVs");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
