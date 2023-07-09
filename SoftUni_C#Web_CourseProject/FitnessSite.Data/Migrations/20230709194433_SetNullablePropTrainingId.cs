using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class SetNullablePropTrainingId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises");

            migrationBuilder.AlterColumn<string>(
                name: "TrainingId",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TrainingId1",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId1",
                table: "Exercises",
                column: "TrainingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId1",
                table: "Exercises",
                column: "TrainingId1",
                principalTable: "Trainings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Trainings_TrainingId1",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrainingId1",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TrainingId1",
                table: "Exercises");

            migrationBuilder.AlterColumn<Guid>(
                name: "TrainingId",
                table: "Exercises",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrainingId",
                table: "Exercises",
                column: "TrainingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Trainings_TrainingId",
                table: "Exercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id");
        }
    }
}
