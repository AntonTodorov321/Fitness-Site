using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class RemoveTypeWeightEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TypeWeights_TypeWeightId",
                table: "Exercises");

            migrationBuilder.DropTable(
                name: "TypeWeights");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TypeWeightId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "RestBetweenSets",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TypeWeightId",
                table: "Exercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestBetweenSets",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TypeWeightId",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeWeights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeWeights", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeWeights",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free weight" },
                    { 2, "Dumbbell" },
                    { 3, "Barbell" },
                    { 4, "Backpac" },
                    { 5, "Weightlifting belt" }
                });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RestBetweenSets", "TypeWeightId" },
                values: new object[] { "20", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TypeWeightId",
                table: "Exercises",
                column: "TypeWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TypeWeights_TypeWeightId",
                table: "Exercises",
                column: "TypeWeightId",
                principalTable: "TypeWeights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
