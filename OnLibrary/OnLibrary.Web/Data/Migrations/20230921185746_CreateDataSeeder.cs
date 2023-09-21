using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnLibrary.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateDataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0e7949b4-0a2b-43f7-9ddc-e8822a4b60c0"), null, "User", null },
                    { new Guid("459a979d-8358-4ebb-9758-d8aa35d7c7ff"), null, "Manager", null },
                    { new Guid("6505ec93-b8ee-418b-a3d7-13fc3e3ffc96"), null, "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5f4c76d3-79b0-4923-86a7-511ac60c2ab9"), 0, "c8b16313-8c4d-4c05-a09a-2ae351b901f8", "manager@onlibrary.com", true, true, null, "MANAGER@ONLIBRARY.COM", "MANAGER@ONLIBRARY.COM", "AQAAAAIAAYagAAAAEIoUSDhLNAxg7aM1erjvYEI4/dVtYtlveYCVQJNTGXPrt5/1S2xVyFVBc+0yTpRKTg==", "+8801856817465", false, "FC37C84E276C4D978DF9054129D0CB23", false, "manager@onlibrary.com" },
                    { new Guid("e26967f0-ce4c-4c14-8a0b-45beb8c9eb48"), 0, "759ab515-87b6-456b-8662-0d1a096d081f", "admin@onlibrary.com", true, true, null, "ADMIN@ONLIBRARY.COM", "ADMIN@ONLIBRARY.COM", "AQAAAAIAAYagAAAAEDJkoybmVMh0gSurwDklCeJpb7wCBftLgldI3eFxHQzD1St2XqbHhsD7HdC0tuOH+A==", "+8801856817465", false, "BFCC7B453A8B4B6C8A4C93EE28A3B4A8", false, "admin@onlibrary.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("459a979d-8358-4ebb-9758-d8aa35d7c7ff"), new Guid("5f4c76d3-79b0-4923-86a7-511ac60c2ab9") },
                    { new Guid("6505ec93-b8ee-418b-a3d7-13fc3e3ffc96"), new Guid("e26967f0-ce4c-4c14-8a0b-45beb8c9eb48") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0e7949b4-0a2b-43f7-9ddc-e8822a4b60c0"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("459a979d-8358-4ebb-9758-d8aa35d7c7ff"), new Guid("5f4c76d3-79b0-4923-86a7-511ac60c2ab9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6505ec93-b8ee-418b-a3d7-13fc3e3ffc96"), new Guid("e26967f0-ce4c-4c14-8a0b-45beb8c9eb48") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("459a979d-8358-4ebb-9758-d8aa35d7c7ff"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6505ec93-b8ee-418b-a3d7-13fc3e3ffc96"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5f4c76d3-79b0-4923-86a7-511ac60c2ab9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e26967f0-ce4c-4c14-8a0b-45beb8c9eb48"));
        }
    }
}
