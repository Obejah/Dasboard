using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboardscrum.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "3bc199fe-3df6-42b4-9836-966df8f101df");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "780aefcd-de61-4e3d-b6f0-8b9af0656de6");

            migrationBuilder.AddColumn<DateTime>(
                name: "Datum",
                table: "Standup",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25c7e657-a614-4dfa-b8a0-b2b7bcb7ce6f", null, "Docent", "DOCENT" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bfce5781-c258-48fb-8322-95b5826f07c3", null, "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "25c7e657-a614-4dfa-b8a0-b2b7bcb7ce6f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "bfce5781-c258-48fb-8322-95b5826f07c3");

            migrationBuilder.DropColumn(
                name: "Datum",
                table: "Standup");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3bc199fe-3df6-42b4-9836-966df8f101df", null, "Docent", "DOCENT" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "780aefcd-de61-4e3d-b6f0-8b9af0656de6", null, "Student", "STUDENT" });
        }
    }
}
