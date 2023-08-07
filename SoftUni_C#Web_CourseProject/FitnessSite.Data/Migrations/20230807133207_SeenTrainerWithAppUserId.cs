using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class SeenTrainerWithAppUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("5b39b703-a3b5-484b-9289-2bb3b778765b"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("9e4ab043-010c-4681-b263-a789e4ae606b"));
   
            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Description", "FirstName", "ImageUrl", "LastName", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[,]
                {
                    { new Guid("03a1dacd-5a29-448f-bf03-81e0a82f08a2"), new Guid("673fc005-4fbb-403b-8931-61c02f901f56"), "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.", "Ivan", "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE=", "Ivanov", 89.99m, 23, "0895543981", 31 },
                    { new Guid("2ec0dcd1-a6e7-4e36-8111-75ee3645af84"), new Guid("3cb73cf9-de66-4109-aa37-b36b72787df7"), "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.", "Maria", "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU=", "Asenova", 84.99m, 21, "0875587458", 28 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("0227c4f2-c3ba-4ae7-9d32-48460bc6d5dd"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("310baabb-7c84-4290-8695-585b26735445"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("4f8142b3-89aa-4b99-8ccc-49f0933c1ae0"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("92217844-ecc6-4ee6-8893-e3576571386e"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("9b0dad84-a58d-4cb5-ae7c-2a3b26b00d2a"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("b6b60700-0cb3-4c37-b077-158fda05fd4a"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("03a1dacd-5a29-448f-bf03-81e0a82f08a2"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("2ec0dcd1-a6e7-4e36-8111-75ee3645af84"));

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("37ab2738-2e83-4cc0-ab5e-dd41c50fd359"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3, null },
                    { new Guid("4aaee5ce-08ff-4776-9c18-d97331694e88"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1, null },
                    { new Guid("751c0077-81eb-4887-92af-12f3734f8ac5"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2, null },
                    { new Guid("95476204-8253-4610-811c-3b59b3c49eaf"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1, null },
                    { new Guid("b821afa3-e7a0-4c9f-a814-389b2e2c5b54"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3, null },
                    { new Guid("c08ef61b-08b0-4c95-9752-5ad78cb45791"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Description", "FirstName", "ImageUrl", "LastName", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[,]
                {
                    { new Guid("5b39b703-a3b5-484b-9289-2bb3b778765b"), new Guid("673fc005-4fbb-403b-8931-61c02f901f56"), "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.", "Ivan", "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE=", "Ivanov", 89.99m, 23, "0895543981", 31 },
                    { new Guid("9e4ab043-010c-4681-b263-a789e4ae606b"), new Guid("3cb73cf9-de66-4109-aa37-b36b72787df7"), "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.", "Maria", "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU=", "Asenova", 84.99m, 21, "0875587458", 28 }
                });
        }
    }
}
