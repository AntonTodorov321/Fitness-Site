using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddUserIdInExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("4a80d3f8-1ae9-4469-8cfa-c5b4974de09d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("6e0ce15b-5e32-4262-9265-d79c4f835af4"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9b898905-094f-4acf-a962-31738e1eee07"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("a0885693-fe2b-45d4-b7d0-385abdd789a4"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c82bdc5a-8d93-44e4-ba51-d17f2264b202"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("fa933ee8-2611-496d-bbc6-9d731e77ba94"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1c752277-8207-4d1d-a43c-8422643a82c6"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3, null },
                    { new Guid("459f6bde-2c9f-42ba-b9c5-4416e51760fc"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1, null },
                    { new Guid("6639c1c3-9ecb-4c4f-91ee-862de85f474d"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2, null },
                    { new Guid("98bde593-26f3-4305-9ddd-dfa16b593385"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2, null },
                    { new Guid("dfbea820-d0e5-40db-bd18-5a1e23be533f"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1, null },
                    { new Guid("f43d786c-c848-4fa2-a8fe-ab574fba4c3d"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_UserId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_UserId",
                table: "Exercises");

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1c752277-8207-4d1d-a43c-8422643a82c6"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("459f6bde-2c9f-42ba-b9c5-4416e51760fc"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("6639c1c3-9ecb-4c4f-91ee-862de85f474d"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("98bde593-26f3-4305-9ddd-dfa16b593385"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("dfbea820-d0e5-40db-bd18-5a1e23be533f"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("f43d786c-c848-4fa2-a8fe-ab574fba4c3d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Exercises");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId" },
                values: new object[,]
                {
                    { new Guid("4a80d3f8-1ae9-4469-8cfa-c5b4974de09d"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1 },
                    { new Guid("6e0ce15b-5e32-4262-9265-d79c4f835af4"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1 },
                    { new Guid("9b898905-094f-4acf-a962-31738e1eee07"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3 },
                    { new Guid("a0885693-fe2b-45d4-b7d0-385abdd789a4"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2 },
                    { new Guid("c82bdc5a-8d93-44e4-ba51-d17f2264b202"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2 },
                    { new Guid("fa933ee8-2611-496d-bbc6-9d731e77ba94"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3 }
                });
        }
    }
}
