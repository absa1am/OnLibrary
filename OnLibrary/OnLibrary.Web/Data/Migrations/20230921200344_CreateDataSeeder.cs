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
                    { new Guid("0e7949b4-0a2b-43f7-9ddc-e8822a4b60c0"), "0E7949B4-0A2B-43F7-9DDC-E8822A4B60C0", "User", "USER" },
                    { new Guid("459a979d-8358-4ebb-9758-d8aa35d7c7ff"), "459A979D-8358-4EBB-9758-D8AA35D7C7FF", "Manager", "MANAGER" },
                    { new Guid("6505ec93-b8ee-418b-a3d7-13fc3e3ffc96"), "6505EC93-B8EE-418B-A3D7-13FC3E3FFC96", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5f4c76d3-79b0-4923-86a7-511ac60c2ab9"), 0, "80291039-b167-4c01-bbab-2b6cfaa66cf4", "manager@onlibrary.com", true, true, null, "MANAGER@ONLIBRARY.COM", "MANAGER@ONLIBRARY.COM", "AQAAAAIAAYagAAAAEGhMTmeSm0r/ZagGOuhUWDBkP/VSVjy2P/fkRYfY706k0Ys+U0aj7dLMQrw3+UM5EA==", "+8801856817465", false, "FC37C84E276C4D978DF9054129D0CB23", false, "manager@onlibrary.com" },
                    { new Guid("e26967f0-ce4c-4c14-8a0b-45beb8c9eb48"), 0, "4ee9d04c-f13e-4d75-abe4-7e57247c0031", "admin@onlibrary.com", true, true, null, "ADMIN@ONLIBRARY.COM", "ADMIN@ONLIBRARY.COM", "AQAAAAIAAYagAAAAEEQqK4eUea3iiof2kuPl3+NDTjykuSpVxJwreilZq9d7HP1r2SFrnt9Q6LYKoRCFLQ==", "+8801856817465", false, "BFCC7B453A8B4B6C8A4C93EE28A3B4A8", false, "admin@onlibrary.com" }
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
