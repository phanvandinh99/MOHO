using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class updateproductcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AppUsers_AppUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AppUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Products");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "03ef24fa-8a1b-4c4f-943c-f9444a8507dd");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "461119af-604b-434e-8dbc-2718cedae860");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("939528cd-a6f3-450b-053b-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "4ff6df71-aeb4-43d8-b493-172b1eeba60b");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "475bcb4c-db41-419d-9473-8d2c9bc66849");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb7820b9-d861-4eb9-9440-4cefd5c8a824", "AQAAAAEAACcQAAAAEJxO1arkpgU1ZKHm1lS8IrdO2P/lXuEpdejkc3k9lOCkoAaIzGw1JKBunUi0CUVRww==" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserId",
                table: "Products",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AppUsers_AppUserId",
                table: "Products",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
