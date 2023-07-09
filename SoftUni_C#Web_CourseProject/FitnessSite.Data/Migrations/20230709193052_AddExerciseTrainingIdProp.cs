using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddExerciseTrainingIdProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_ApplicationUserId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ApplicationUserId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Exercises");

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "TrainingId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ApplicationUserId",
                table: "Trainings",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ApplicationUserId",
                table: "Exercises",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_ApplicationUserId",
                table: "Exercises",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
