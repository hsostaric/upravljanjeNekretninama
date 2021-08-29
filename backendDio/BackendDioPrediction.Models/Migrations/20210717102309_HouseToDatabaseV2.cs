using Microsoft.EntityFrameworkCore.Migrations;

namespace BackendDioPrediction.Models.Migrations
{
    public partial class HouseToDatabaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Bedrooms = table.Column<float>(type: "real", nullable: false),
                    Bathrooms = table.Column<float>(type: "real", nullable: false),
                    SqftLiving = table.Column<int>(type: "int", nullable: false),
                    SqftLot = table.Column<int>(type: "int", nullable: false),
                    Floors = table.Column<float>(type: "real", nullable: false),
                    Waterfront = table.Column<bool>(type: "bit", nullable: false),
                    View = table.Column<int>(type: "int", nullable: false),
                    Condition = table.Column<int>(type: "int", nullable: false),
                    YearBuilt = table.Column<int>(type: "int", nullable: false),
                    YearRenovated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
