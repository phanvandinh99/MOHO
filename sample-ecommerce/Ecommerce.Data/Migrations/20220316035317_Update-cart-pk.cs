using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class Updatecartpk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "8bda8044-27a6-4c45-814e-b5603b43f5c9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "73fcbcf2-abd5-4722-bf4a-1adbce7ffb73");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("939528cd-a6f3-450b-053b-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "5e01816e-3f7c-4500-b9d0-06d88fc9002d");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "b8798f6d-2c26-4458-addd-c33d01fe9265");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "82300688-6b00-4243-98e2-46f137a183bb", "AQAAAAEAACcQAAAAEFe4a27Pcl5pOGTYhd8qQNRZJIdH5Sr181mWZOvXvbklNKheZsH4+oYA0hzRu2iqag==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "00733023-3eff-4b93-a6e9-f9b8f369e17c");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "c659c21b-73e6-406f-bc3f-ee78e5d8406a");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("939528cd-a6f3-450b-053b-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "9a26f1e9-1a80-4738-adff-d8c82d0eed13");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "b6db08e8-7536-4275-9eb4-83cd1f798799");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bf4a6d7-645a-435d-9ad3-c470337c1c17", "AQAAAAEAACcQAAAAEPK+wFA7PkqBAYYWAyI8Lu5khgCaj1DvalD3qsLz73zs/DYAdC5QkEkkXPWdCgARZg==" });
        }
    }
}