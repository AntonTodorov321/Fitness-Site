using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class IsBelongToSomeoneRemove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBelongToSomeone",
                table: "Exercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("174d1363-5c1b-4b5c-aaf5-39d3bc813aa8"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("6d93cbfe-b72d-4dd7-a134-0098e8ea9880"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("82955134-16f0-43fe-9e63-ddd7759a6a20"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("d021f579-8380-43f4-9d5c-48c298ecd1b2"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("dd6d3684-1752-412b-9224-6dd772957f29"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("eaf31fe6-2076-49ea-a380-8970ca2da744"));

            migrationBuilder.AddColumn<bool>(
                name: "IsBelongToSomeone",
                table: "Exercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "IsBelongToSomeone", "Kilogram", "Name", "Reps", "Sets", "TypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("02cedcac-af59-4f5d-ab87-aa5636c10706"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", false, null, "Cycling", null, null, 2, null },
                    { new Guid("3779789b-0641-440b-bbf4-bf5b66c2e043"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", false, null, "Push-Ups", "10", "4", 1, null },
                    { new Guid("58d1f4aa-ae6e-44ed-95a6-79edc4e5c0e3"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", false, null, "Pull-Ups", null, null, 2, null },
                    { new Guid("750b0aad-6595-4da2-b4ff-b904e2ddffdd"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", false, null, "Bench Press", "10 - 12", "4", 3, null },
                    { new Guid("894edced-f368-4128-9e14-f953a7670c4a"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", false, null, "Plank", "8", "3", 1, null },
                    { new Guid("fc7afded-09a2-4699-a963-d9c4ee0f0244"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", false, null, "Squat", "8 - 10", "3-4", 3, null }
                });
        }
    }
}
