using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN232.Lab2.CoffeeStore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3631e38b-60dd-4d1a-af7f-a26f21c2ef82"),
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37a7c5df-4898-4fd4-8e5f-d2abd4b57520"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("51ef7e08-ff07-459b-8c55-c7ebac505103"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Staff", "STAFF" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEORmgzlK6735op4c4IlVapW4Q/xhDapI4UnvnvSo3exPGmvOkS9Tx50qEoUCEHuCSQ==", new DateTime(2025, 10, 12, 16, 15, 10, 575, DateTimeKind.Utc).AddTicks(5518) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33f41895-b601-4aa1-8dc4-8229a9d07008"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEE783cemGngyCTLF6dfYCVvrCH1RpAn58T5F/BF9OiLBeDW6ewoqc8nH+lhD91TmNg==", new DateTime(2025, 10, 12, 16, 15, 10, 509, DateTimeKind.Utc).AddTicks(5872) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe014130-bfb5-443b-9989-9c8f90d1065f"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEA7DymLeJPZxG2fJwSVUv2Q8z76QPcIe+TmRkf1dSyUkopiVr6Ue3SUfmED8JPbMWA==", new DateTime(2025, 10, 12, 16, 15, 10, 636, DateTimeKind.Utc).AddTicks(6370) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3631e38b-60dd-4d1a-af7f-a26f21c2ef82"),
                column: "Name",
                value: "admin");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("37a7c5df-4898-4fd4-8e5f-d2abd4b57520"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "parent", "PARENT" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("51ef7e08-ff07-459b-8c55-c7ebac505103"),
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "teacher", "TEACHER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEIpcJsur7pKyKZCGje6MhcrbzqQ7ITJ3bWB1iILTYcH5Oz9DUowMRKRGY+e5JIx4Ag==", new DateTime(2025, 10, 9, 1, 51, 49, 38, DateTimeKind.Utc).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33f41895-b601-4aa1-8dc4-8229a9d07008"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEFrCJhsvxmlgY3YkkVzw0h1ujlff7zZU4zPEF+7zAaxbYgfnkgT22MG9a5hmiMd/aQ==", new DateTime(2025, 10, 9, 1, 51, 48, 977, DateTimeKind.Utc).AddTicks(2081) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe014130-bfb5-443b-9989-9c8f90d1065f"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEKfcc6f4wRxjaNqudo9aAf7a3dr7XsjGpc33QPKL3m96qW8P83vcXR7kNfc+TMtTgA==", new DateTime(2025, 10, 9, 1, 51, 49, 96, DateTimeKind.Utc).AddTicks(2294) });
        }
    }
}
