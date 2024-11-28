using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Data.Migrations
{
    public partial class updateordercol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a972a81f-1051-4613-920b-24d0a370ecfc");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("92a170c6-118c-45c9-053a-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "99aad336-4ee4-48fd-8b9e-87d1ce28d1d1");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("939528cd-a6f3-450b-053b-08d83b9c9ecb"),
                column: "ConcurrencyStamp",
                value: "be4425cb-68ee-4f17-b38f-8916d38fabfe");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("aa6f243a-5cbc-42d5-a432-08d83b5447b1"),
                column: "ConcurrencyStamp",
                value: "5c6c1f6b-8c65-4d53-99bb-15d7d51b5451");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6272e0ee-7a59-4ecf-b872-acce4ec73e58", "AQAAAAEAACcQAAAAEE9D3bHJYjAsleGM8POhQUCGJccC+r35i7INCX//xHTzyas+xsvZxAGXwf9mEjUtvA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "AppUserId",
                table: "Orders",
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
    }
}
