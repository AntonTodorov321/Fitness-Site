using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddPropLastNameToTrainer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("646fc80a-0361-43ec-bfd2-28644687a273"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("896bb72d-45f8-45f6-958e-619bd3979d82"));

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Trainers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Trainers",
                type: "nvarchar(747)",
                maxLength: 747,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Email", "FirstName", "ImageUrl", "LastName", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[,]
                {
                    { new Guid("0291f83e-22ab-46c6-820f-738318f84e75"), "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.", "ivantrainer@gmail.com", "Ivan", "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE=", "Ivanov", 89.99m, 23, "0895543981", 31 },
                    { new Guid("5cdf48bb-09a1-4a2c-8a57-9edc675deaf9"), "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.", "mariatrainer@gmail.com", "Maria", "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU=", "Asenova", 84.99m, 21, "0875587458", 28 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("1c882ee5-c7f9-49a8-9e8b-a98117e1bb38"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("85e9cdd2-d9c5-4167-87e3-0e5bd638c5cb"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("a04411c7-8530-44c2-9641-ab13efd88da1"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c1099f8d-b5b7-4e58-89f2-8367ec3c7fb3"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c13c8c2c-8fba-4e7d-8b21-6213160a16a0"));

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: new Guid("c311f0da-214f-4c88-ae22-9d4d12b2b4c5"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("0291f83e-22ab-46c6-820f-738318f84e75"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("5cdf48bb-09a1-4a2c-8a57-9edc675deaf9"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Trainers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Trainers",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "Description", "ImageUrl", "Kilogram", "Name", "Reps", "Sets", "TypeId", "UserId" },
                values: new object[,]
                {
                    { new Guid("005b9bd2-b59a-46d8-be56-8f4ab3c70414"), "An exercise in which a person, keeping a prone position with thehandspalms down under the shoulders", "https://blog.nasm.org/hubfs/power-pushups.jpg", null, "Push-Ups", "10", "4", 1, null },
                    { new Guid("1a18c4b0-f218-4278-9444-a86b2633a13d"), "Pullup is a challenging upper body exercise where you grip an overhead bar  and lift your body until your chin is above that bar.", "https://calisthenicsworldwide.com/wp-content/uploads/2023/02/152-CWW_20-pull-ups.jpg", null, "Pull-Ups", null, null, 2, null },
                    { new Guid("71bcf2f7-1aa2-4770-bfb2-88f1f5f9f44f"), "Start in a tabletop position on your hands and knees, then lower down toyour forearms with your elbows stacked beneath your shoulders. Step yo  feet back until your body makes a line from shoulders to heels.", "https://blog-images-1.pharmeasy.in/blog/production/wp-content/uploads/2021/01/06152556/3.jpg", null, "Plank", "8", "3", 1, null },
                    { new Guid("9ecf4e35-6793-4419-9727-777d7a9bbbf6"), "Cycling, also, when on a two-wheeled bicycle, called bicycling or biking  is the use of cycles for transport, recreation, exercise or sport. People engaged in cycling are referred to as cyclists,bicyclists, or bikers.", "https://images.immediate.co.uk/production/volatile/sites/21/2022/05/Cube-Axial-WS-12-45369da.jpg?quality=90&resize=620%2C413", null, "Cycling", null, null, 2, null },
                    { new Guid("b1c62c92-fd84-48a8-911a-172627af9956"), "A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up. During the descent, the hip and knee joints flex while the ankle joint dorsiflexes", "https://www.muscleandfitness.com/wp-content/uploads/2019/02/1109-Barbell-Back-Squat-GettyImages-614107160.jpg?quality=86&strip=all", null, "Squat", "8 - 10", "3-4", 3, null },
                    { new Guid("c6b4b234-b85c-42fb-8eef-7c1f704582f4"), "The bench press is a compound exercise that targets the muscles of the upper body. It involves lying on a bench and pressing weight upward using either a barbell or a pair of dumbbells.", "https://cdn.muscleandstrength.com/sites/default/files/barbell-bench-press_0.jpg", null, "Bench Press", "10 - 12", "4", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "Description", "Email", "ImageUrl", "Name", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[,]
                {
                    { new Guid("646fc80a-0361-43ec-bfd2-28644687a273"), "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.", "ivantrainer@gmail.com", "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE=", "Ivan", 89.99m, 23, "0895543981", 31 },
                    { new Guid("896bb72d-45f8-45f6-958e-619bd3979d82"), "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.", "mariatrainer@gmail.com", "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU=", "Maria", 84.99m, 21, "0875587458", 28 }
                });
        }
    }
}
