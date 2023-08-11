using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class removeUnusedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "IsEnded",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "IsDoneForToday",
                table: "TrainingExercises");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("604e402d-75b2-427d-8257-ebcada529edc"));

            migrationBuilder.DeleteData(
                table: "Trainers",
                keyColumn: "Id",
                keyValue: new Guid("be87d8ba-9a39-494f-9935-473cc70b620e"));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Trainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsEnded",
                table: "Trainings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "Trainings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Trainings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDoneForToday",
                table: "TrainingExercises",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Description", "FirstName", "ImageUrl", "LastName", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[] { new Guid("78d84a8b-245e-4691-984c-1ffb1c85afce"), new Guid("3cb73cf9-de66-4109-aa37-b36b72787df7"), "Hello, my name is Maria.I've been going to the gym since i was 16, and when i grow up i decide to become professional trainer. I work mostly with men.", "Maria", "https://media.istockphoto.com/id/856797530/photo/portrait-of-a-beautiful-woman-at-the-gym.jpg?s=612x612&w=0&k=20&c=0wMa1MYxt6HHamjd66d5__XGAKbJFDFQyu9LCloRsYU=", "Asenova", 84.99m, 21, "0875587458", 28 });

            migrationBuilder.InsertData(
                table: "Trainers",
                columns: new[] { "Id", "ApplicationUserId", "Description", "FirstName", "ImageUrl", "LastName", "PricePerMonth", "StartedAt", "TelefoneNumber", "Year" },
                values: new object[] { new Guid("c2a1d108-a670-41b9-ae62-548e4ba1730c"), new Guid("673fc005-4fbb-403b-8931-61c02f901f56"), "Hello, my name is Ivan. I know every type of exercise and i will be glad if i work with you! I work mostly with men.", "Ivan", "https://media.istockphoto.com/id/1072395722/photo/fitness-trainer-at-gym.jpg?s=612x612&w=0&k=20&c=3VBLCgbxG3bGNRp9Sc3tN_7G-g_DxXhGk9rhuZo-jkE=", "Ivanov", 89.99m, 23, "0895543981", 31 });
        }
    }
}
