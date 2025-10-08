using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRN232.Lab2.CoffeeStore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RefreshTokenExpiryTime", "UserName" },
                values: new object[] { "staff@example.com", "STAFF@EXAMPLE.COM", "STAFF", "AQAAAAIAAYagAAAAEL1CRCfaq7wd33KU5ee6h7rEO+fnUumv/D75W9UThA/qYTy9HAxuVKjSxE4GG0s17w==", new DateTime(2025, 10, 15, 8, 56, 55, 458, DateTimeKind.Utc).AddTicks(3727), "staff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33f41895-b601-4aa1-8dc4-8229a9d07008"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEAMX5EBQUVj9D36pj/G7j7jN/vE72ubxLrHzDkuR6kINGT7cJLLPSaf7ItfHD53Y6g==", new DateTime(2025, 10, 15, 8, 56, 55, 393, DateTimeKind.Utc).AddTicks(9765) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe014130-bfb5-443b-9989-9c8f90d1065f"),
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RefreshTokenExpiryTime", "UserName" },
                values: new object[] { "user@example.com", "USER@EXAMPLE.COM", "USER", "AQAAAAIAAYagAAAAEB5PHEn5K6ymFwlqZFN5Yb+LjYz4HKfpQwuHTyYWpswXz+HeUnjHD879m74Pv4bxWw==", new DateTime(2025, 10, 15, 8, 56, 55, 519, DateTimeKind.Utc).AddTicks(5322), "user" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RefreshTokenExpiryTime", "UserName" },
                values: new object[] { "teacher@example.com", "TEACHER@EXAMPLE.COM", "TEACHER", "AQAAAAIAAYagAAAAEORmgzlK6735op4c4IlVapW4Q/xhDapI4UnvnvSo3exPGmvOkS9Tx50qEoUCEHuCSQ==", new DateTime(2025, 10, 12, 16, 15, 10, 575, DateTimeKind.Utc).AddTicks(5518), "teacher" });

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
                columns: new[] { "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "RefreshTokenExpiryTime", "UserName" },
                values: new object[] { "parent@example.com", "PARENT@EXAMPLE.COM", "PARENT", "AQAAAAIAAYagAAAAEA7DymLeJPZxG2fJwSVUv2Q8z76QPcIe+TmRkf1dSyUkopiVr6Ue3SUfmED8JPbMWA==", new DateTime(2025, 10, 12, 16, 15, 10, 636, DateTimeKind.Utc).AddTicks(6370), "parent" });
        }
    }
}
