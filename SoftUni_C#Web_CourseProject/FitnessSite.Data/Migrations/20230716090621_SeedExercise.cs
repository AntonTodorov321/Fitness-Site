using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class SeedExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId" },
                values: new object[,]
                {
                    { new Guid("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1 },
                    { new Guid("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2 },
                    { new Guid("6587e2a8-e9f1-4fd9-bd7e-503078be010b"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3 },
                    { new Guid("88922675-b7df-4a4a-9313-231d2c13a3a2"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1 },
                    { new Guid("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3 },
                    { new Guid("a22ab0dd-3e6a-444f-b21d-b7f69707bb28"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("6587e2a8-e9f1-4fd9-bd7e-503078be010b"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("88922675-b7df-4a4a-9313-231d2c13a3a2"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("a22ab0dd-3e6a-444f-b21d-b7f69707bb28"));

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId" },
                values: new object[,]
                {
                    { new Guid("05d52ade-82a5-40f6-a540-37c7de726374"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2 },
                    { new Guid("1f5fcf60-9896-434d-840f-02ed9c000083"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1 },
                    { new Guid("28dca095-9d64-47c8-8754-9cd7507cb3b9"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3 },
                    { new Guid("678aa66b-c4f4-4c09-9eaf-2c40a7e99cc1"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2 },
                    { new Guid("809036ec-9e9b-4cfa-bb29-355172c1841e"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1 },
                    { new Guid("948046b5-96fb-4ab2-8ba5-96198c6723f4"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3 }
                });
        }
    }
}
