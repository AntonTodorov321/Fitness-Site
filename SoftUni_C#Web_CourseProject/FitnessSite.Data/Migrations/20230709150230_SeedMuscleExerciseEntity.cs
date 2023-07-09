using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class SeedMuscleExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", "Pull-Ups" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Sets", "TypeId" },
                values: new object[] { "3-4", 3 });

            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 5 },
                    { 4, 4 },
                    { 5, 2 },
                    { 5, 5 },
                    { 6, 4 },
                    { 6, 6 }
                });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Abs");

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Back");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 2, 6 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "An exercise in which a person, keeping a prone position with the handspalms down under the shoulders");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Start in a tabletop position on your hands and knees, then lower down to your forearms with your elbows stacked beneath your shoulders. Step your feet back until your body makes a line from shoulders to heels.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "ImageUrl", "Name" },
                values: new object[] { "Running is a method of terrestrial locomotion allowing humans and other animals to move rapidly on foot. Running is a type of gait characterized by an aerial phase in which all feet are above the ground", "https://post.healthline.com/wp-content/uploads/2020/01/Runner-training-on-running-track-732x549-thumbnail.jpg", "Running" });

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking,[3] is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.");

            migrationBuilder.UpdateData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Sets", "TypeId" },
                values: new object[] { "", 1 });

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Legs");

            migrationBuilder.UpdateData(
                table: "Muscles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Abs");
        }
    }
}
