using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddMuscleExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MuscleExercises",
                columns: table => new
                {
                    MuscleId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MuscleExercises", x => new { x.ExerciseId, x.MuscleId });
                    table.ForeignKey(
                        name: "FK_MuscleExercises_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MuscleExercises_Muscles_MuscleId",
                        column: x => x.MuscleId,
                        principalTable: "Muscles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId" },
                values: new object[,]
                {
                    { new Guid("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"), 2 },
                    { new Guid("23f41c9e-da15-4282-b5cc-1cbadb6ca92e"), 5 },
                    { new Guid("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"), 1 },
                    { new Guid("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"), 2 },
                    { new Guid("2d41e21a-e8c8-4c7a-8690-3a846772b6b6"), 7 },
                    { new Guid("6587e2a8-e9f1-4fd9-bd7e-503078be010b"), 2 },
                    { new Guid("88922675-b7df-4a4a-9313-231d2c13a3a2"), 3 },
                    { new Guid("88922675-b7df-4a4a-9313-231d2c13a3a2"), 6 },
                    { new Guid("88922675-b7df-4a4a-9313-231d2c13a3a2"), 7 },
                    { new Guid("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"), 4 },
                    { new Guid("8cb1af1b-b63a-458b-adfa-dc077a02c4f9"), 6 },
                    { new Guid("a22ab0dd-3e6a-444f-b21d-b7f69707bb28"), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MuscleExercises_MuscleId",
                table: "MuscleExercises",
                column: "MuscleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MuscleExercises");

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
    }
}
