using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PRN232.Lab2.CoffeeStore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class DB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEAQNyh+mFoFlXm2mk3PxvRrpZlYhqlEr677x5cEChlIY8wA+/thn1668Bej70z9TlQ==", new DateTime(2025, 10, 15, 9, 0, 21, 296, DateTimeKind.Utc).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("33f41895-b601-4aa1-8dc4-8229a9d07008"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAECnij7OrGcp+6UHBNopqg/aTikdolYJDGIlxJJD4dyO5xp8gM/9/BNMxTTHG48NQew==", new DateTime(2025, 10, 15, 9, 0, 21, 233, DateTimeKind.Utc).AddTicks(9569) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fe014130-bfb5-443b-9989-9c8f90d1065f"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEEF4BFjbZh6PyZERt9PgmXu6A1/ZNoggZByBKrYPnbrWd4YD1Ydlys1MZ+a5l7nPpg==", new DateTime(2025, 10, 15, 9, 0, 21, 358, DateTimeKind.Utc).AddTicks(4934) });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DeviceToken", "Email", "EmailConfirmed", "FullName", "IsActive", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("df1a8683-c075-49ca-af63-095b3a491d04"), 0, null, "seed-9", null, "user3@example.com", true, "", true, false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEEf9vRx5x8PL0LGQlZuy+cMiojeNI+4jNTFuqmJ0bINXJd0FAk1slLbFm1ZC0WKaAg==", null, false, "", new DateTime(2025, 10, 15, 9, 0, 21, 480, DateTimeKind.Utc).AddTicks(7495), "seed-8", false, "user3" },
                    { new Guid("fcd27e3f-37ec-4e9b-96bf-eca690d172cc"), 0, null, "seed-9", null, "user2@example.com", true, "", true, false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEEswEY1LNQPahkTX4rK/yxTh/99NSZXtxJvWTfPIfA2y7F4Izwyf0UUYhhTsJxiCvw==", null, false, "", new DateTime(2025, 10, 15, 9, 0, 21, 420, DateTimeKind.Utc).AddTicks(2373), "seed-8", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("37a7c5df-4898-4fd4-8e5f-d2abd4b57520"), new Guid("fcd27e3f-37ec-4e9b-96bf-eca690d172cc") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("37a7c5df-4898-4fd4-8e5f-d2abd4b57520"), new Guid("fcd27e3f-37ec-4e9b-96bf-eca690d172cc") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("df1a8683-c075-49ca-af63-095b3a491d04"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fcd27e3f-37ec-4e9b-96bf-eca690d172cc"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("09097277-2705-40c2-bce5-51dbd1f4c1e6"),
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEL1CRCfaq7wd33KU5ee6h7rEO+fnUumv/D75W9UThA/qYTy9HAxuVKjSxE4GG0s17w==", new DateTime(2025, 10, 15, 8, 56, 55, 458, DateTimeKind.Utc).AddTicks(3727) });

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
                columns: new[] { "PasswordHash", "RefreshTokenExpiryTime" },
                values: new object[] { "AQAAAAIAAYagAAAAEB5PHEn5K6ymFwlqZFN5Yb+LjYz4HKfpQwuHTyYWpswXz+HeUnjHD879m74Pv4bxWw==", new DateTime(2025, 10, 15, 8, 56, 55, 519, DateTimeKind.Utc).AddTicks(5322) });
        }
    }
}
