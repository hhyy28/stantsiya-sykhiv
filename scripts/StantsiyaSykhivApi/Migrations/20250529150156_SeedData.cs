using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StantsiyaSykhivApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Tasks",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, "Create backend API", 1, "API Dev" },
                    { 2, "Build UI", 2, "Frontend UI" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "ProjectId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Development" },
                    { 2, 2, "UI Design" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "AssigneeId", "Description", "EndDate", "ProjectId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Initial project setup", new DateTime(2025, 5, 31, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8031), 1, new DateTime(2025, 5, 27, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8023), "ToDo", "Setup project" },
                    { 2, 3, "UI for login", new DateTime(2025, 5, 30, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8034), 2, new DateTime(2025, 5, 28, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8034), "InProgress", "Create login form" }
                });

            migrationBuilder.InsertData(
                table: "Columns",
                columns: new[] { "Id", "BoardId", "Order", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "To Do" },
                    { 2, 1, 2, "In Progress" },
                    { 3, 1, 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "TaskId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 1, "Don't forget logging", 1, new DateTime(2025, 5, 29, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8078) },
                    { 2, 2, "UI is almost done", 2, new DateTime(2025, 5, 29, 15, 1, 55, 771, DateTimeKind.Utc).AddTicks(8079) }
                });

            migrationBuilder.InsertData(
                table: "TaskColumnLinks",
                columns: new[] { "ColumnId", "TaskId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TaskColumnLinks",
                keyColumns: new[] { "ColumnId", "TaskId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "TaskColumnLinks",
                keyColumns: new[] { "ColumnId", "TaskId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Columns",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Tasks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
